using System.Web.Http;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.Web.Filters.Api;

namespace OnlinerTracker.Web.Controllers.Api
{
	[Authentication]
	public class TrackingProductController : ApiControllerBase
	{
		private readonly IProductTrackingService trackingProductService;
		private readonly IProductService productService;

		public TrackingProductController(IProductTrackingService trackingProductService, IProductService productService)
		{
			this.trackingProductService = trackingProductService;
			this.productService = productService;
		}

		// положу что бы не потерять
		// http://www.restapitutorial.com/lessons/httpmethods.html

		[Route("tracking/start/{id:int:min(1)}")]
		[HttpPost]
		public IHttpActionResult Track(int id, Product product)
		{
			productService.Add(product, PrincipalUser.Id);
			return Ok();
		}

		[Route("tracking/stop/{id:int:min(1)}")]
		[HttpPut]
		public IHttpActionResult Untrack(int id)
		{
			trackingProductService.Untrack(id, PrincipalUser.Id);
			return Ok();
		}
		
		[Route("tracking/remove/{id:int:min(1)}")]
		[HttpDelete]
		public IHttpActionResult Remove(int id)
		{
			trackingProductService.Remove(id, PrincipalUser.Id);
			return Ok();
		}
	}
}
