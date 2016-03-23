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
			return Ok(userService.GetInfo(PrincipalUser.Id));
		}

		[HttpPut]
		[Route("user/update")]
		public IHttpActionResult Update(UserInfo userInfo)
		{
			// финт ушами, можно сделать роут типо: user/update/id, но это только для красоты
			// т.к. любой пользователь, в этом случае, сможет изменить данные любого другого
			userService.Update(PrincipalUser.Id, userInfo);
			return Ok();
		}
	}
}