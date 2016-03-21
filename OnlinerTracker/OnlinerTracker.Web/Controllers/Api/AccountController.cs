using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.Web.Filters.Api;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class AccountController : ApiController
	{
		private readonly ISocNetworkAuthService authService;

		public AccountController(ISocNetworkAuthService authService)
		{
			this.authService = authService;
		}

		[Authentication(AllowAnonymous = true)]
		[Route("signin/{socNetwork}")]
		[HttpGet]
		[ResponseType(typeof(string))]
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