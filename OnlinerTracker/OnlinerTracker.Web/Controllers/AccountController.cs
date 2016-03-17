using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlinerTracker.BusinessLogic.Abstract;
using System.Collections.Specialized;
using OnlinerTracker.Web.Extensions;
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


		[Route("~/api/account/{socNetwork}")]
		public string GetLoginLink(string socNetwork)
		{
			return _auth.GetAuthUrl(socNetwork);
		}

		[Route("~/api/account/auth")]
		public string GetAccessToken()
		{
			// как хранить имя соц сети
			//var coll = Request.GetQueryNameValuePairs();
			var coll = HttpUtility.ParseQueryString(Request.RequestUri.Query);

			var view = _auth.GetProtectedResources(coll, "Twitter");
			return "something";
		}

	}
}
