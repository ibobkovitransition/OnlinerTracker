using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Ninject;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.Web.Filters.Api
{
	public class AuthenticationAttribute : System.Attribute, IAuthenticationFilter
	{
		public bool AllowMultiple => false;

		public bool AllowAnonymous { get; set; } = false;

		private readonly string cookieName = "onliner_tracker";

		[Inject]
		public IHashService HashService { get; set; }

		[Inject]
		public IUnitOfWork UnitOfWork { get; set; }

		public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			// аттрибут allow anonymous не работает, гугл не спас
			if (AllowAnonymous)
			{
				return Task.FromResult(0);
			}

			// is there cookie set
			var cookies = context.Request.Headers.GetCookies(cookieName);

			if (!cookies.Any())
			{
				context.ErrorResult = new AuthenticationFailureResult("Missing credentials", context.Request);
				return Task.FromResult(0);
			}

			// is there onliner_tracker cookies
			var entry = cookies[0].Cookies.FirstOrDefault(x => x.Name == cookieName);

			if (string.IsNullOrWhiteSpace(entry?.Name))
			{
				context.ErrorResult = new AuthenticationFailureResult("Missing credentials", context.Request);
				return Task.FromResult(0);
			}

			// is there user in db
			var hashedSocialNetworkUserId = HashService.Decrypt(entry.Value);
			var user = UnitOfWork.UserRepository.FindBy(x => x.SocialId == hashedSocialNetworkUserId);

			if (user == null)
			{
				context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", context.Request);
				return Task.FromResult(0);
			}

			context.Principal = new PrincipalUser(user.Id);

			return Task.FromResult(0);
		}

		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			return Task.FromResult(0);
		}
	}
}