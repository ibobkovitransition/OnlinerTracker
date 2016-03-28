using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Implementations.Tracking
{
	public class ProductPriceTrackingService : IPriceTrackingService
	{
		private readonly IProductService productService;
		private readonly IProductSearchService productSearchService;
		private readonly List<ProductPriceHistory> result;

		public ProductPriceTrackingService(IProductService productService, IProductSearchService productSearchService)
		{
			this.productService = productService;
			this.productSearchService = productSearchService;
			result = new List<ProductPriceHistory>();
		}

		public IEnumerable<ProductPriceHistory> FindChangedPrices()
		{
			var products = productService.Get();
			FindChanges(products);
			return result;
		}

		private void FindChanges(IEnumerable<Product> products)
		{
			foreach (var product in products)
			{
				var searchResult = productSearchService.Search(product.FullName, 1, 10);
				AddToResultIfChanged(product, searchResult.Products.Where(fetchedProduct => product.Id == fetchedProduct.Id));
			}
		}

		private void AddToResultIfChanged(Product product, IEnumerable<Product> fetchedProducts)
		{
			foreach (var fetchedProduct in fetchedProducts)
			{
				if (product.Price.Min != (fetchedProduct.Price?.Min ?? 0) || product.Price.Max != (fetchedProduct.Price?.Max ?? 0))
				{
					result.Add(Parse(fetchedProduct));
				}
				break;
			}
		}

		private ProductPriceHistory Parse(Product product)
		{
			return new ProductPriceHistory
			{
				CreatedOn = DateTime.Now,
				Product = product,
				ProductId = product.Id,
				MinPrice = product.Price?.Min ?? 0,
				MaxPrice = product.Price?.Max ?? 0
			};
		}
	}
}
