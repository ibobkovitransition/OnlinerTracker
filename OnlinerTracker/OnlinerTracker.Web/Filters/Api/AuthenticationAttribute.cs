using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using Ninject;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;

namespace OnlinerTracker.Web.Filters.Api
{
	public class AuthenticationAttribute : System.Attribute, IAuthenticationFilter
	{
		public bool AllowMultiple => false;

		private readonly string cookieName = "onliner_tracker";

		[Inject]
		public IHashService HashService { get; set; }

		[Inject]
		public IUserService UserService { get; set; }

		public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			var isAnonymousAllowed = context.ActionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

			if (isAnonymousAllowed)
			{
				return Task.FromResult(0);
			}

			var cookies = context.Request.Headers.GetCookies(cookieName);

			if (!cookies.Any())
			{
				context.ErrorResult = new AuthenticationFailureResult("Missing credentials", context.Request);
				return Task.FromResult(0);
			}

			var entry = cookies[0].Cookies.FirstOrDefault(x => x.Name == cookieName);

			if (string.IsNullOrWhiteSpace(entry?.Name))
			{
				context.ErrorResult = new AuthenticationFailureResult("Missing credentials", context.Request);
				return Task.FromResult(0);
			}

			var userId = HashService.Decrypt(entry.Value);
			var user = UserService.GetBySocialId(userId);

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