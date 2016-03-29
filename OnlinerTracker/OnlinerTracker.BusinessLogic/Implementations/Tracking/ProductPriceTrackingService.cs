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
		private readonly List<PriceHistory> result;

		public ProductPriceTrackingService(IProductService productService, IProductSearchService productSearchService)
		{
			this.productService = productService;
			this.productSearchService = productSearchService;
			result = new List<PriceHistory>();
		}

		public IEnumerable<PriceHistory> FindChangedPrices()
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
					result.Add(Parse(product, fetchedProduct));
				}
				break;
			}
		}

		private PriceHistory Parse(Product oldProduct, Product fetchedProduct)
		{
			return new PriceHistory
			{
				CreatedAt = DateTime.Now,

				// отдаем продукт с актуальной ценой
				Product = fetchedProduct,
				ProductId = fetchedProduct.Id,

				// сюда, в свою очередь, пишем старную цену
				MinPrice = oldProduct.Price?.Min ?? 0,
				MaxPrice = oldProduct.Price?.Max ?? 0
			};
		}
	}
}
