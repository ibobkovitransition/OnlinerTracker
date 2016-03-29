using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.Onliner;
using OnlinerTracker.DataAccess.Interfaces;
using Product = OnlinerTracker.DataAccess.Enteties.Product;
using ProductTracking = OnlinerTracker.DataAccess.Enteties.ProductTracking;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class ProductService : IProductService
	{
		private readonly IProductSearchService productSearchService;
		private readonly IProductTrackingService productTrackingService;
		private readonly IRepository<Product> productRepository;
		private readonly IRepository<ProductTracking> productTrackingRepository;

		public ProductService(IProductSearchService productSearchService, IProductTrackingService productTrackingService, IRepository<Product> productRepository, IRepository<ProductTracking> productTrackingRepository)
		{
			this.productSearchService = productSearchService;
			this.productTrackingService = productTrackingService;
			this.productRepository = productRepository;
			this.productTrackingRepository = productTrackingRepository;
		}

		public SearchResult Search(string productName, int page, int size, int userId)
		{
			var result = productSearchService.Search(productName, page, size);
			MarkTrackedProducts(userId, result.Products);
			return result;
		}

		public IEnumerable<Models.Onliner.Product> Get()
		{
			return productRepository.GetEntities().Select(x => x.ToModel());
		}

		public void Add(Models.Onliner.Product product, int userId)
		{
			AddIfNotExsists(product);
			productTrackingService.Track(product.Id, userId);
		}

		public void Delete(int productId)
		{
			productRepository.Detach(productId);
			productRepository.Commit();
		}

		public void Update(Models.Onliner.Product product)
		{
			productRepository.Update(product.ToEntity());
			productRepository.Commit();
		}

		public void Update(IEnumerable<Models.Onliner.Product> products)
		{
			foreach (var product in products)
			{
				productRepository.Update(product.ToEntity());
			}
			productRepository.Commit();
		}

		private void AddIfNotExsists(Models.Onliner.Product product)
		{
			var entry = productRepository.FindBy(x => x.Id == product.Id);
			if (entry == null)
			{
				var parsed = product.ToEntity();
				productRepository.Attach(parsed);
				productRepository.Commit();
			}
		}

		private void MarkTrackedProducts(int userId, IEnumerable<Models.Onliner.Product> productsToMark)
		{
			var trackedProducts = productTrackingRepository.GetEntities(x => x.UserId == userId);

			foreach (var product in productsToMark)
			{
				var entry = trackedProducts.FirstOrDefault(x => x.ProductId == product.Id);
				if (entry != null)
				{
					product.IsTracked = entry.Enabled;
					product.IsAdded = true;
				}
			}
		}
	}
}