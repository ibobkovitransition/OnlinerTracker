using System.Web.Http;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.Web.Filters;
using OnlinerTracker.Web.Filters.Api;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Controllers.Api
{
	[Authentication]
	public class TrackingProductController : ApiController
	{
		private readonly ITrackingProductService trackingProductService;
		private readonly IProductService productService;
		private readonly ICookieService cookieService;
		private readonly string cookieName = "onliner_tracker";

		public TrackingProductController(ITrackingProductService trackingProductService, ICookieService cookieService, IProductService productService)
		{
			this.trackingProductService = trackingProductService;
			this.cookieService = cookieService;
			this.productService = productService;
		}

		// положу что бы не потерять
		// http://www.restapitutorial.com/lessons/httpmethods.html

		[Route("tracking/start/{id:int:min(1)}")]
		[HttpPost]
		public IHttpActionResult Track(int id, Product product)
		{
			var user = (PrincipalUser)User;
			productService.Add(product, user.UserId);
			return Ok();
		}

		[Route("tracking/stop/{id:int:min(1)}")]
		[HttpPut]
		public IHttpActionResult Untrack(int id)
		{
			var user = (PrincipalUser)User;
			trackingProductService.Untrack(id, user.UserId);
			return Ok();
		}
		
		[Route("tracking/remove/{id:int:min(1)}")]
		[HttpDelete]
		public IHttpActionResult Remove(int id)
		{
			var user = (PrincipalUser)User;
			trackingProductService.Remove(id, user.UserId);
			return Ok();
		}
	}
}
