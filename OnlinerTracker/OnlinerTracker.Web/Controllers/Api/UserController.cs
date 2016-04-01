using System.Web.Http;
using System.Web.Http.Description;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.User;

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
		[Route("user")]
		public IHttpActionResult UserInfo()
		{
			return Ok(userService.Get(PrincipalUser.Id));
		}

		[HttpPut]
		[Route("user")]
		public IHttpActionResult Update(UserInfo userInfo)
		{
			if (userInfo.Id != PrincipalUser.Id)
			{
				return BadRequest("Wrong user id");
			}

			userService.Update(userInfo);
			return Ok();
		}
	}
}