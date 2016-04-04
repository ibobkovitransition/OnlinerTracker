using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

		private readonly string userCookieName = "onliner_tracker";
		private readonly string connectionCookieName = "connection_id";

		[Inject]
		public IHashService HashService { get; set; }

		[Inject]
		public IUserService UserService { get; set; }

		public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
		{
			if (IsAnonymousAllowed(context))
			{
				return Task.FromResult(0);
			}

			var cookies = context.Request.Headers.GetCookies(userCookieName);

			if (!IsCookiesExists(cookies))
			{
				context.ErrorResult = new AuthenticationFailureResult("Missing credentials", context.Request);
				return Task.FromResult(0);
			}

			var userCookie = cookies[0].Cookies.FirstOrDefault(x => x.Name == userCookieName);
			var connectionIdCookie = cookies[0].Cookies.FirstOrDefault(x => x.Name == connectionCookieName);
			var user = UserService.GetBySocialId(HashService.Decrypt(userCookie?.Value));

			if (user == null)
			{
				context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", context.Request);
				return Task.FromResult(0);
			}

			context.Principal = new PrincipalUser(user.Id, connectionIdCookie?.Value);

			return Task.FromResult(0);
		}

		private bool IsAnonymousAllowed(HttpAuthenticationContext context)
		{
			return context.ActionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
		}

		private bool IsCookiesExists(IEnumerable<CookieHeaderValue> cookies)
		{
			return cookies.Any();
		}

		public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
		{
			return Task.FromResult(0);
		}
	}
}