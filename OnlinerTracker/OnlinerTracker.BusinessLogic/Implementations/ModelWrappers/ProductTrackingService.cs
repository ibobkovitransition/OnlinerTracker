using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;
using Product = OnlinerTracker.BusinessLogic.Models.Onliner.Product;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class ProductTrackingService : IProductTrackingService
	{
		private readonly IUnitOfWork unitOfWork;

		public ProductTrackingService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public IEnumerable<Product> Get(int userId)
		{
			var productsTracking = unitOfWork.ProductTrackingRepository.GetEntities(
				x => x.UserId == userId,
				x => x.Product, x => x.User);

			return productsTracking.Select(x => x.ToModel());
		}

		public IEnumerable<ProductTracking> Get()
		{
			var productTracking = unitOfWork.ProductTrackingRepository.GetEntities(
				null,
				x => x.Product, x => x.User, x => x.Product.PriceHistory);

			return productTracking;
		}

		public void Increase(int productId, int userId, bool track)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);
			trackedProduct.Increase = track;
			unitOfWork.ProductTrackingRepository.Update(trackedProduct);
			unitOfWork.Commit();
		}

		public void Decrease(int productId, int userId, bool track)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);
			trackedProduct.Decrease = track;
			unitOfWork.ProductTrackingRepository.Update(trackedProduct);
			unitOfWork.Commit();
		}

		public void Track(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				unitOfWork.ProductTrackingRepository.Attach(new ProductTracking
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
				unitOfWork.ProductTrackingRepository.Update(trackedProduct);
			}

			unitOfWork.Commit();
		}

		public void Untrack(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			trackedProduct.Enabled = false;
			unitOfWork.ProductTrackingRepository.Update(trackedProduct);
			unitOfWork.Commit();
		}

		public void Remove(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			unitOfWork.ProductTrackingRepository.Detach(trackedProduct);
			unitOfWork.Commit();
		}

		private ProductTracking GetTrackedProduct(int productId, int userId)
		{
			return unitOfWork.ProductTrackingRepository.FindBy(x => x.ProductId == productId && x.UserId == userId);
		}
	}
}
