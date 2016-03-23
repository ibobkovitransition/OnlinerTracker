using System.Web.Http;
using System.Web.Http.Description;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class UserController : ApiControllerBase
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpGet]
		[ResponseType(typeof(UserInfo))]
		[Route("user/info")]
		public IHttpActionResult UserInfo()
		{
			return Ok(userService.GetUserInfo(PrincipalUser.Id));
		}

		//[HttpPut]
		//[Route("user/email")]
	}
}