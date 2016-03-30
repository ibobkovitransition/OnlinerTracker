using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.DataAccess.Interfaces;
using ProductTracking = OnlinerTracker.DataAccess.Enteties.ProductTracking;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class ProductTrackingService : IProductTrackingService
	{
		private readonly IRepository<ProductTracking> productTrackingRepository;

		public ProductTrackingService(IRepository<ProductTracking> productTrackingRepository)
		{
			this.productTrackingRepository = productTrackingRepository;
		}

		public IEnumerable<Models.Onliner.Product> Get(int userId)
		{
			var productsTracking = productTrackingRepository.GetEntities(
				x => x.UserId == userId,
				x => x.Product, x => x.User);

			return productsTracking.Select(x => x.ToModel());
		}

		// запилить одельную ProductTracking
		public IEnumerable<ProductTracking> Get()
		{
			var productTracking = productTrackingRepository.GetEntities(
				null,
				x => x.Product, x => x.User, x => x.Product.PriceHistory);

			return productTracking;
		}

		public void Increase(int productId, int userId, bool track)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);
			trackedProduct.Increase = track;
			productTrackingRepository.Update(trackedProduct);
			productTrackingRepository.Commit();
		}

		public void Decrease(int productId, int userId, bool track)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);
			trackedProduct.Decrease = track;
			productTrackingRepository.Update(trackedProduct);
			productTrackingRepository.Commit();
		}

		public void Track(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				productTrackingRepository.Attach(new ProductTracking
				{
					CreatedAt = DateTime.Now,
					UserId = userId,
					ProductId = productId,
					Enabled = true
				});
			}
			else
			{
				trackedProduct.Enabled = true;
				productTrackingRepository.Update(trackedProduct);
			}

			productTrackingRepository.Commit();
		}

		public void Untrack(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			trackedProduct.Enabled = false;
			productTrackingRepository.Update(trackedProduct);
			productTrackingRepository.Commit();
		}

		public void Remove(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			productTrackingRepository.Detach(trackedProduct);
			productTrackingRepository.Commit();
		}

		private ProductTracking GetTrackedProduct(int productId, int userId)
		{
			return productTrackingRepository.FindBy(x => x.ProductId == productId && x.UserId == userId);
		}
	}
}
