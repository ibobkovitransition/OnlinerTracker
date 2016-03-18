using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Controllers.Mvc
{
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

			var userId = userService.AddUser(Request.QueryString, socNetwork);

			if (userId.IsNullOrWhiteSpace())
			{
				return HttpNotFound();
			}

			var encryptedId = hashService.Encrypt(userId);
			cookieService.PutCookie(ControllerContext.HttpContext.Response, "onliner_tracker", encryptedId, 10);

			return Redirect("/#/Home");
		}
	}
}
