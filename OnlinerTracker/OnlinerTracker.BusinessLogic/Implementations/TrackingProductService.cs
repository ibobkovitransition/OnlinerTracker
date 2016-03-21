﻿using System;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class TrackingProductService : ITrackingProductService
	{
		private readonly IUnitOfWork unitOfWork;

		public TrackingProductService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void Track(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				unitOfWork.TrackedProducts.Attach(new TrackingProduct
				{
					CreatedOn = DateTime.Now,
					UserId = userId,
					ProductId = productId,
					Enabled = true
				});
			}
			else
			{
				trackedProduct.Enabled = true;
				unitOfWork.TrackedProducts.Update(trackedProduct);
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
			unitOfWork.TrackedProducts.Update(trackedProduct);
			unitOfWork.Commit();
		}

		public void Remove(int productId, int userId)
		{
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			unitOfWork.TrackedProducts.Detach(trackedProduct);
			unitOfWork.Commit();
		}

		private TrackingProduct GetTrackedProduct(int productId, int userId)
		{
			var trackedProduct = unitOfWork.TrackedProducts
				.FindBy(x => x.ProductId == productId && x.UserId == userId);

			return trackedProduct;
		}
	}
}
