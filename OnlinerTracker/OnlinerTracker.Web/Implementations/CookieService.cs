using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Implementations
{
	public class CookieService : ICookieService
	{
		public void PutCookie(HttpResponseBase response, string name, string value, int experationDays)
		{
			var cookie = new HttpCookie(name)
			{
				Value = value,
				Expires = DateTime.Now.AddDays(experationDays)
			};

			response.Cookies.Add(cookie);
		}

		public string GetCookie(HttpRequestHeaders headers, string name)
		{
			var clientCookie = headers.GetCookies(name).FirstOrDefault();
			return clientCookie?[name].Value;
		}
	}
}