using System;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using System.Web;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Controllers.Mvc
{
	[RoutePrefix("api/v1/account")]
	public class AccountController : Controller
	{
		private readonly IUserService userService;
		private readonly IHashService hashService;
		private readonly ICookieService cookieService;

		public AccountController(IUserService userService, IHashService hashService, ICookieService cookieService)
		{
			this.userService = userService;
			this.hashService = hashService;
			this.cookieService = cookieService;
		}

		[Route("auth/{socNetwork}")]
		public ActionResult AuthCallBack(string socNetwork)
		{
			if (socNetwork.IsNullOrWhiteSpace())
			{
				return HttpNotFound();
			}

			var authedUser = userService.AuthService.GetUserInfo(Request.QueryString, socNetwork);
			var encryptedId = hashService.Encrypt(authedUser.UserId);
			userService.AuthUser(authedUser);
			cookieService.PutCookie(ControllerContext.HttpContext.Response, "onliner_tracker", encryptedId, 10);

			return Redirect("/#/Home");
		}
	}
}
