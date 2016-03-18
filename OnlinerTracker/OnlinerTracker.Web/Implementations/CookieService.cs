using System;
using System.Web;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Implementations
{
	public class CookieService : ICookieService
	{
		public void PutCookie(HttpResponseBase response, string name, string value, int experationDays)
		{
			HttpCookie cookie = new HttpCookie(name)
			{
				Value = value,
				Expires = DateTime.Now.AddDays(experationDays)
			};
			response.Cookies.Add(cookie);
		}
	}
}