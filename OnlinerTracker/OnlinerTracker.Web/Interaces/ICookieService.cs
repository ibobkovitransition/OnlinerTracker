using System.Web;
using System.Web.Http.Controllers;

namespace OnlinerTracker.Web.Interaces
{
	public interface ICookieService
	{
		void PutCookie(HttpResponseBase response, string name, string value, int experationDays);
	}
}
