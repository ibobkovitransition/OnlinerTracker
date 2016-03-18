using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.Web.Controllers.Api
{

	public class ProductController : ApiController
	{
		private readonly IProductService productService;

		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}

		[Route("products/{productName}/page/{page:int:min(1)}/size/{size:int:min(1)}")]
		[HttpGet]
		[ResponseType(typeof(SearchResult))]
		public IHttpActionResult SeachProducts(string productName, int page, int size)
		{
			if (productName.IsNullOrWhiteSpace())
			{
				return NotFound();
			}

			return Ok(productService.Search(productName, page, size));
		}
	}
}
