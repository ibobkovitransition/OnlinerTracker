using System;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;
using System.Web;

namespace OnlinerTracker.Web.Controllers.Mvc
{
	/// <summary>
	///  security - на случай если взбредет в angular поставлю поддержку html5, в этом случае /#/ исчезнет и возникнут неопределенности
	/// </summary>
	[RoutePrefix("api/v1/account")]
	public class AccountController : Controller
	{
		private readonly ISocNetworkAuthService authService;
		private readonly IRepository<User> repository;
		private readonly IUnitOfWork uow;
		private readonly IHashService hashService;

		public AccountController(ISocNetworkAuthService authService, IUnitOfWork uow, IHashService hashService)
		{
			this.authService = authService;
			this.uow = uow;
			this.hashService = hashService;
			repository = uow.UserRepository;
		}

		[Route("auth/{socNetwork}")]
		public ActionResult AuthCallBack(string socNetwork)
		{
			if (socNetwork.IsNullOrWhiteSpace())
			{
				return HttpNotFound();
			}

			var authedUser = authService.GetUserInfo(Request.QueryString, socNetwork);
			var user = repository.FindBy(x => x.UserId == authedUser.UserId);

			if (user == null)
			{
				repository.Create(new User{
					FirstName = authedUser.FirstName,
					CreatedOn = DateTime.Now,
					PhotoUri = authedUser.PhotoUri,
					UserId = authedUser.UserId
				});

				uow.Commit();
			}

			var userHash = hashService.Encrypt(authedUser.UserId);
			HttpCookie cookie = new HttpCookie("auth_cookie");
			cookie.Value = userHash;
			ControllerContext.HttpContext.Response.Cookies.Add(cookie);

			return Redirect("/#/Home");
		}
	}
}
