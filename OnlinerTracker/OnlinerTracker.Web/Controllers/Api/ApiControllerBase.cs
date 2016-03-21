using System.Web.Http;
using OnlinerTracker.Web.Filters;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class ApiControllerBase : ApiController
	{
		protected PrincipalUser PrincipalUser => User as PrincipalUser;
	}
}