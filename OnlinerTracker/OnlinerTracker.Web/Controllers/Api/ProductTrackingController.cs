using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.Onliner;
using OnlinerTracker.Web.Filters.Api;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Controllers.Api
{
	[Authentication]
	public class ProductTrackingController : ApiControllerBase
	{
		private readonly IProductTrackingService trackingProductService;
		private readonly IProductService productService;
		private readonly INotificator notificator;

		public ProductTrackingController(
			IProductTrackingService trackingProductService, 
			IProductService productService, 
			INotificator notificator)
		{
			this.trackingProductService = trackingProductService;
			this.productService = productService;
			this.notificator = notificator;
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
			//notificator.Notify(PrincipalUser.ConnectionId, "Tracking started");
			notificator.Notify("chat1", "started");
			return Ok();
		}

		[HttpPut]
		[Route("tracking/stop/{id:int:min(1)}")]
		public IHttpActionResult Untrack(int id)
		{
			trackingProductService.Untrack(id, PrincipalUser.Id);
			//notificator.Notify(PrincipalUser.ConnectionId, "Tracking stopped");
			notificator.Notify("chat2", "stopped");
			return Ok();
		}

		[HttpDelete]
		[Route("tracking/remove/{id:int:min(1)}")]
		public IHttpActionResult Remove(int id)
		{
			trackingProductService.Remove(id, PrincipalUser.Id);
			notificator.Notify(PrincipalUser.ConnectionId, "Removed");
			return Ok();
		}

		[HttpPut]
		[Route("tracking/increase/{id:int:min(1)}")]
		public IHttpActionResult TrackIncrease(int id, Product product)
		{
			trackingProductService.Increase(id, PrincipalUser.Id, product.Increase);
			notificator.Notify(PrincipalUser.ConnectionId, 
				$"Price increase tracking { (product.Increase ? "started" : "stopped") }");

			return Ok();
		}

		[HttpPut]
		[Route("tracking/decrease/{id:int:min(1)}")]
		public IHttpActionResult TrackDecrease(int id, Product product)
		{
			trackingProductService.Decrease(id, PrincipalUser.Id, product.Decrease);
			notificator.Notify(PrincipalUser.ConnectionId,
				$"Price decrease tracking { (product.Decrease ? "started" : "stopped") }");

			return Ok();
		}
	}
}
