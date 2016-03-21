using System.Web.Http;
using OnlinerTracker.Web.Filters;

namespace OnlinerTracker.Web.Controllers.Api.Basic
{
	public class ExtendedApiController : ApiController
	{
		protected readonly PrincipalUser PrincipalUser;

		public ExtendedApiController()
		{
			PrincipalUser = User as PrincipalUser;
		}
	}
}