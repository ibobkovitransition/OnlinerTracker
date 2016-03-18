using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;

namespace OnlinerTracker.Web.Controllers.Api
{
	[RoutePrefix("api/v1/account")]
	public class AccountController : ApiController
	{
		private readonly ISocNetworkAuthService authService;

		public AccountController(ISocNetworkAuthService authService)
		{
			this.authService = authService;
		}

		[Route("signIn/{socNetwork}")]
		[HttpGet]
		[ResponseType(typeof(string))]
		public IHttpActionResult AuthUrl(string socNetwork)
		{
			if (socNetwork.IsNullOrWhiteSpace())
			{
				return NotFound();
			}

			return Ok(authService.GetAuthUrl(socNetwork));
		}
	}
}