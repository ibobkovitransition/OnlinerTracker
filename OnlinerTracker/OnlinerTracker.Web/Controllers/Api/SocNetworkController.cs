using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Abstract;

namespace OnlinerTracker.Web.Controllers.Api
{
	[RoutePrefix("api/v1/account")]
	public class SocNetworkController : ApiController
	{
		private readonly ISocNetworkAuthService authService;

		public SocNetworkController(ISocNetworkAuthService authService)
		{
			this.authService = authService;
		}

		[Route("signIn/{socNetwork}"), HttpGet]
		[ResponseType(typeof(string))]
		public IHttpActionResult AuthUrl(string socNetwork)
		{
			if (socNetwork.IsNullOrWhiteSpace())
				return NotFound();

			return Ok(authService.GetRequestToken(socNetwork));
		}

	}
}