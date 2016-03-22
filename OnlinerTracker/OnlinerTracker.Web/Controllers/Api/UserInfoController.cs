using System.Web.Http;
using System.Web.Http.Description;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class UserInfoController : ApiControllerBase
	{
		private readonly IUserInfoService userInfoService;

		public UserInfoController(IUserInfoService userInfoService)
		{
			this.userInfoService = userInfoService;
		}

		[HttpGet]
		[ResponseType(typeof(UserInfo))]
		[Route("userinfo")]
		public IHttpActionResult UserInfo()
		{
			return Ok(userInfoService.UserInfo(PrincipalUser.Id));
		}
	}
}