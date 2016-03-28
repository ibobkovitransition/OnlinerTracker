﻿using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductSearchService productSearchService;
		private readonly IUnitOfWork unitOfWork;
		private readonly IProductTrackingService productTrackingService;

		public ProductService(IProductSearchService productSearchService, IUnitOfWork unitOfWork, IProductTrackingService productTrackingService)
		{
			this.productSearchService = productSearchService;
			this.unitOfWork = unitOfWork;
			this.productTrackingService = productTrackingService;
		}

		public SearchResult Search(string productName, int page, int size, int userId)
		{
			var result = productSearchService.Search(productName, page, size);
			MarkTrackedProducts(userId, result.Products);
			return result;
		}

		public IEnumerable<Product> Get()
		{
			return unitOfWork.ProductRepository.GetEntities().Select(x => x.ToModel());
		}

		public void Add(Product product, int userId)
		{
			AddIfNotExsists(product);
			productTrackingService.Track(product.Id, userId);
		}

		public void Delete(int productId)
		{
			unitOfWork.ProductRepository.Detach(productId);
			unitOfWork.Commit();
		}

		public void Update(Product product)
		{
			unitOfWork.ProductRepository.Update(product.ToEntity());
			unitOfWork.Commit();
		}

		public void Update(IEnumerable<Product> products)
		{
			foreach (var product in products)
			{
				unitOfWork.ProductRepository.Update(product.ToEntity());
			}
			unitOfWork.Commit();
		}

		private void AddIfNotExsists(Product product)
		{
			var entry = unitOfWork.ProductRepository.FindBy(x => x.Id == product.Id);
			if (entry == null)
			{
				var parsed = product.ToEntity();
				unitOfWork.ProductRepository.Attach(parsed);
				unitOfWork.Commit();
			}
		}

		private void MarkTrackedProducts(int userId, IEnumerable<Product> productsToMark)
		{
			var trackedProducts = unitOfWork.ProductTrackingRepository.GetEntities(x => x.UserId == userId);

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