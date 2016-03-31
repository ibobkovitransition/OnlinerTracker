using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.BusinessLogic.Models.Onliner;
using OnlinerTracker.DataAccess.Interfaces;
using EntityProductTracking = OnlinerTracker.DataAccess.Enteties.ProductTracking;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class ProductTrackingService : IProductTrackingService
	{
		private readonly IRepository<EntityProductTracking> productTrackingRepository;

		public ProductTrackingService(IRepository<EntityProductTracking> productTrackingRepository)
		{
			this.productTrackingRepository = productTrackingRepository;
		}

		public IEnumerable<Product> Get(int userId)
		{
			return productTrackingRepository.GetEntities(
				x => x.UserId == userId,
				x => x.Product,
				x => x.User).Select(x => x.ToProduct());
		}

		public IEnumerable<ProductTracking> GetActualByProducts(IEnumerable<Product> products)
		{
			var productIds = products.Select(x => x.Id);

			return productTrackingRepository.GetEntities(
				x => x.Enabled &&
				(x.Increase || x.Decrease) &&
				productIds.Contains(x.ProductId)).Select(x => x.ToModel());
		}

		public void Increase(int productId, int userId, bool track)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);
			trackedProduct.Increase = track;
			productTrackingRepository.Update(trackedProduct.ToEntity());
			productTrackingRepository.Commit();
		}

		public void Decrease(int productId, int userId, bool track)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);
			trackedProduct.Decrease = track;
			productTrackingRepository.Update(trackedProduct.ToEntity());
			productTrackingRepository.Commit();
		}

		public void Track(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				var entity = new ProductTracking
				{
					CreatedAt = DateTime.Now,
					UserInfoId = userId,
					ProductId = productId,
					Enabled = true,
					Decrease = true,
					Increase = true
				};

				productTrackingRepository.Attach(entity.ToEntity());
			}
			else
			{
				trackedProduct.Enabled = true;
				productTrackingRepository.Update(trackedProduct.ToEntity());
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
			productTrackingRepository.Update(trackedProduct.ToEntity());
			productTrackingRepository.Commit();
		}

		public void Remove(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			productTrackingRepository.Detach(trackedProduct.ToEntity());
			productTrackingRepository.Commit();
		}

		private ProductTracking GetTrackedProduct(int productId, int userId)
		{
			return productTrackingRepository.FindBy(
				x => x.ProductId == productId && x.UserId == userId)?.ToModel();
		}
	}
}
