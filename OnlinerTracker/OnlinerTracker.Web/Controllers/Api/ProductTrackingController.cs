using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.Web.Filters.Api;

namespace OnlinerTracker.Web.Controllers.Api
{
	[Authentication]
	public class ProductTrackingController : ApiControllerBase
	{
		private readonly IProductTrackingService trackingProductService;
		private readonly IProductService productService;

		public ProductTrackingController(IProductTrackingService trackingProductService, IProductService productService)
		{
			this.trackingProductService = trackingProductService;
			this.productService = productService;
		}

		// положу что бы не потерять
		// http://www.restapitutorial.com/lessons/httpmethods.html

		[HttpGet]
		[ResponseType(typeof(IEnumerable<Product>))]
		[Route("tracking/products")]
		public IHttpActionResult Get()
		{
			var result = trackingProductService.Get(PrincipalUser.Id);
			return Ok(result);
		}

		[HttpPost]
		[Route("tracking/start/{id:int:min(1)}")]
		public IHttpActionResult Track(int id, Product product)
		{
			productService.Add(product, PrincipalUser.Id);
			return Ok();
		}

		[HttpPut]
		[Route("tracking/stop/{id:int:min(1)}")]
		public IHttpActionResult Untrack(int id)
		{
			trackingProductService.Untrack(id, PrincipalUser.Id);
			return Ok();
		}

		[HttpDelete]
		[Route("tracking/remove/{id:int:min(1)}")]
		public IHttpActionResult Remove(int id)
		{
			trackingProductService.Remove(id, PrincipalUser.Id);
			return Ok();
		}

		[HttpPut]
		[Route("tracking/increase/{id:int:min(1)}")]
		public IHttpActionResult TrackIncrease(int id, Product product)
		{
			trackingProductService.Increase(id, PrincipalUser.Id, product.Increase);
			return Ok();
		}

		[HttpPut]
		[Route("tracking/decrease/{id:int:min(1)}")]
		public IHttpActionResult TrackDecrease(int id, Product product)
		{
			trackingProductService.Decrease(id, PrincipalUser.Id, product.Decrease);
			return Ok();
		}
	}
}
