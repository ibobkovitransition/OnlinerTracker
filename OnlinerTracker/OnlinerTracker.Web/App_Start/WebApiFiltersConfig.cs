using System.Web.Http.Filters;
using OnlinerTracker.Web.Filters.Api;

namespace OnlinerTracker.Web
{
	public class WebApiFiltersConfig
	{
		public static void Register(HttpFilterCollection filters)
		{
			filters.Add(new AuthenticationAttribute());
		}
	}
}