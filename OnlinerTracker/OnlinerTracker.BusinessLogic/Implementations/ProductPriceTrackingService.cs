using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ProductPriceTrackingService : IPriceTrackingService
	{
		private readonly IProductService productService;
		private readonly IProductSearchService productSearchService;

		public ProductPriceTrackingService(IProductService productService, IProductSearchService productSearchService)
		{
			this.productService = productService;
			this.productSearchService = productSearchService;
		}

		public IEnumerable<ProductPriceHistory> FindChangedPrices()
		{
			var products = productService.Get();

			var result = FetchResult(products);
			return result;
		}

		// косо криво
		private IEnumerable<ProductPriceHistory> FetchResult(IEnumerable<Product> products)
		{
			var result = new List<ProductPriceHistory>();

			foreach (var product in products)
			{
				var searchResult = productSearchService.Search(product.FullName, 1, 10);

				// TODO: починить  (fetchedProduct.Price?.Min ?? 0) || product.Price.Max != (fetchedProduct.Price?.Max ?? 0)
				foreach (var fetchedProduct in searchResult.Products.Where(fetchedProduct => product.Id == fetchedProduct.Id))
				{
					if (product.Price.Min != (fetchedProduct.Price?.Min ?? 0) || product.Price.Max != (fetchedProduct.Price?.Max ?? 0))
					{
						result.Add(new ProductPriceHistory
						{
							CreatedOn = DateTime.Now,
							Product = fetchedProduct,
							ProductId = fetchedProduct.Id,
							MinPrice = fetchedProduct.Price.Min,
							MaxPrice = fetchedProduct.Price.Max
						});
					}

					break;
				}
			}

			return result;
		}
	}
}
