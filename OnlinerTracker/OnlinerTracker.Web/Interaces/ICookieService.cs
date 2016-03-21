using System.Net.Http.Headers;
using System.Web;

namespace OnlinerTracker.Web.Interaces
{
	public interface ICookieService
	{
		void PutCookie(HttpResponseBase response, string name, string value, int experationDays);

		string GetCookie(HttpRequestHeaders headers, string name);
	}
}
