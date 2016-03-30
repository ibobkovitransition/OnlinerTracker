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

		public ProductPriceTrackingService(IProductService productService, IProductSearchService productSearchService)
		{
			this.productService = productService;
			this.productSearchService = productSearchService;
		}

		public IEnumerable<PriceHistory> FindChangedPrices()
		{
			var products = productService.Get();
			return FindChanges(products);
		}

		private List<PriceHistory> FindChanges(IEnumerable<Product> products)
		{
			var result = new List<PriceHistory>();

			foreach (var product in products)
			{
				var searchResult = productSearchService.Search(product.FullName, 1, 10);
				var entry = GetChanged(product, searchResult.Products.Where(fetchedProduct => product.Id == fetchedProduct.Id));
				if (entry != null)
				{
					result.Add(entry);
				}
			}

			return result;
		}

		private PriceHistory GetChanged(Product product, IEnumerable<Product> fetchedProducts)
		{
			foreach (var fetchedProduct in fetchedProducts)
			{
				if (product.Price.Min != (fetchedProduct.Price?.Min ?? 0) || product.Price.Max != (fetchedProduct.Price?.Max ?? 0))
				{
					return Parse(product, fetchedProduct);
				}
			}

			return null;
		}

		private PriceHistory Parse(Product oldProduct, Product fetchedProduct)
		{
			return new PriceHistory
			{
				CreatedAt = DateTime.Now,

				// отдаем продукт с актуальной ценой
				ProductId = fetchedProduct.Id,
				Product = fetchedProduct,

				// сюда, в свою очередь, пишем старную цену
				MinPrice = oldProduct.Price?.Min ?? 0,
				MaxPrice = oldProduct.Price?.Max ?? 0
			};
		}
	}
}
