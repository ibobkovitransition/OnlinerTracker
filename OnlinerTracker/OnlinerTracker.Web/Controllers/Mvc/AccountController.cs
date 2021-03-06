﻿using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Controllers.Mvc
{
	public class AccountController : Controller
	{
		private readonly IUserService userService;
		private readonly IHashService hashService;
		private readonly ICookieService cookieService;
		private readonly string cookieName = "onliner_tracker";

		public AccountController(IUserService userService, IHashService hashService, ICookieService cookieService)
		{
			this.userService = userService;
			this.hashService = hashService;
			this.cookieService = cookieService;
		}

		[Route("auth/{socialNetwork}")]
		public ActionResult AuthCallBack(string socialNetwork)
		{
			if (socialNetwork.IsNullOrWhiteSpace())
			{
				return HttpNotFound();
			}

			var userId = userService.Create(Request.QueryString, socialNetwork);

			if (userId.IsNullOrWhiteSpace())
			{
				return HttpNotFound();
			}

			var encryptedId = hashService.Encrypt(userId);
			cookieService.PutCookie(ControllerContext.HttpContext.Response, cookieName, encryptedId, 10);

			return Redirect("/#/Home");
		}
	}
}
