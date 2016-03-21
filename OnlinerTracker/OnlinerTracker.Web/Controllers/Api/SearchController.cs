﻿using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.Web.Filters.Api;

namespace OnlinerTracker.Web.Controllers.Api
{
	[Authentication]
	public class SearchController : ApiControllerBase
	{
		private readonly IProductService productService;

		public SearchController(IProductService productService)
		{
			this.productService = productService;
		}
		
		[Route("search/products/{productName}/page/{page:int:min(1)}")]
		[HttpGet]
		[ResponseType(typeof(SearchResult))]
		public IHttpActionResult Search(string productName, int page)
		{
			if (productName.IsNullOrWhiteSpace())
			{
				return BadRequest();
			}

			return Ok(productService.Search(productName, page, PrincipalUser.Id));
		}
	}
}