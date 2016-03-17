using System.Net;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Abstract;
using OnlinerTracker.DataAccess.Abstract;
using OnlinerTracker.DataAccess.Concrete.Ef;
using OnlinerTracker.DataAccess.Enteties;


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

		public AccountController(ISocNetworkAuthService authService, IUnitOfWork uow)
		{
			this.authService = authService;
			this.uow = uow;
			repository = uow.UserRepository;
		}

		[Route("auth/{socNetwork}")]
		public ActionResult AuthCallBack(string socNetwork)
		{
			if (socNetwork.IsNullOrWhiteSpace())
				return HttpNotFound();

			var authResult = authService.GetUserInfo(Request.QueryString, socNetwork);
			var user = repository.FindBy(x => x.SocNetworkId == authResult.UserId);

			//if (user == null)
			//{
			//	repository.Create(new User
			//	{
			//		FirstName = authResult.FirstName,
			//		SocNetworkId = authResult.UserId
			//	});
			//	uow.Commit();
			//}

			//Response.Cookies.Add();


			// hash id 

			// cookie

			// another shit
			// put hash into cookie

			return Redirect("/#/Home");
		}

	}
}
