using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.Web.Interaces;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class SearchController : ApiController
	{
		private readonly IProductService productService;
		private readonly ICookieService cookieService;
		private readonly string cookieName = "onliner_tracker";

		public SearchController(ICookieService cookieService, IProductService productService)
		{
			this.cookieService = cookieService;
			this.productService = productService;
		}

		[Route("search/products/{productName}/page/{page:int:min(1)}")]
		[HttpGet]
		[ResponseType(typeof(SearchResult))]
		public IHttpActionResult Search(string productName, int page)
		{
			string hashedId = cookieService.GetCookie(Request.Headers, cookieName);
			if (hashedId.IsNullOrWhiteSpace())
			{
				return Unauthorized();
			}

			if (productName.IsNullOrWhiteSpace())
			{
				return BadRequest();
			}

			return Ok(productService.Search(productName, page, hashedId));
		}
	}
}