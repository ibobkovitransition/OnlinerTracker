using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class AccountController : ApiControllerBase
	{
		private readonly ISocialNetworkAuthService authService;

		public AccountController(ISocialNetworkAuthService authService)
		{
			this.authService = authService;
		}

		[AllowAnonymous]
		[HttpGet]
		[ResponseType(typeof(string))]
		[Route("signin/{socNetwork}")]
		public IHttpActionResult AuthUrl(string socNetwork)
		{
			if (socNetwork.IsNullOrWhiteSpace())
			{
				return NotFound();
			}

			return Ok(authService.AuthUrl(socNetwork));
		}
	}
}