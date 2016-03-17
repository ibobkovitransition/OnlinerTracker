using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlinerTracker.BusinessLogic.Abstract;
using System.Web;

namespace OnlinerTracker.Web.Controllers
{
	public class AccountController : ApiController
	{
		private readonly ISocialNetworkAuthService _auth;

		public AccountController(ISocialNetworkAuthService auth)
		{
			_auth = auth;
		}

		[Route("~/api/Account/SignIn/{socNetwork}")]
		public string GetRequestToken(string socNetwork)
		{
			return _auth.GetRequestToken(socNetwork);
		}

		[Route("~/api/Account/Auth/{socNetwork}")]
		public HttpResponseMessage GetAccessToken(string socNetwork)
		{
			var uriParams = HttpUtility.ParseQueryString(Request.RequestUri.Query);
			var view = _auth.GetUserInfo(uriParams, socNetwork);

			// put in response

			var response = Request.CreateResponse(HttpStatusCode.Redirect);
			response.Headers.Location = new Uri("http://localhost:38840/#/Home");
			return response;
		}

	}
}
