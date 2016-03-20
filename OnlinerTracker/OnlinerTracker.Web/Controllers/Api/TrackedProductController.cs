using System.Web.Http;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class TrackedProductController : ApiController
	{
		private readonly ITrackedProductService trackService;
		private readonly IProductService productService;
		private readonly ICookieService cookieService;
		private readonly string cookieName = "onliner_tracker";

		public TrackedProductController(ITrackedProductService trackService, ICookieService cookieService, IProductService productService)
		{
			this.trackService = trackService;
			this.cookieService = cookieService;
			this.productService = productService;
		}

		// положу что бы не потерять
		// http://www.restapitutorial.com/lessons/httpmethods.html

		[Route("tracking/start/{id:int:min(1)}")]
		[HttpPost]
		public IHttpActionResult Track(int id, Product product)
		{
			string hashedId = cookieService.GetCookie(Request.Headers, cookieName);
			if (hashedId.IsNullOrWhiteSpace())
			{
				return Unauthorized();
			}

			productService.AddIfNotExsists(product);
			trackService.Track(id, hashedId);

			return Ok();
		}

		[Route("tracking/stop/{id:int:min(1)}")]
		[HttpPut]
		public IHttpActionResult Untrack(int id)
		{
			string hashedId = cookieService.GetCookie(Request.Headers, cookieName);
			if (hashedId.IsNullOrWhiteSpace())
			{
				return Unauthorized();
			}

			trackService.Untrack(id, hashedId);

			return Ok();
		}
		
		[Route("tracking/remove/{id:int:min(1)}")]
		[HttpDelete]
		public IHttpActionResult Remove(int id)
		{
			string hashedId = cookieService.GetCookie(Request.Headers, cookieName);
			if (hashedId.IsNullOrWhiteSpace())
			{
				return Unauthorized();
			}

			trackService.Remove(id, hashedId);

			return Ok();
		}
	}
}
