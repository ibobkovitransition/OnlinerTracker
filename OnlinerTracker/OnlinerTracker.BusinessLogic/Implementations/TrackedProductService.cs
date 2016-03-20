using System;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class TrackedProductService : ITrackedProductService
	{
		private readonly IHashService hashService;
		private readonly IUnitOfWork uow;

		public TrackedProductService(IUnitOfWork uow, IHashService hashService)
		{
			this.hashService = hashService;
			this.uow = uow;
		}

		public void Track(int productId, string hashedSocNetworkUserId)
		{
			var userId = GetUserIdByHashedId(hashedSocNetworkUserId);
			var trackedProduct = GetTrackedProduct(productId, userId);

			if (trackedProduct == null)
			{
				uow.TrackedProducts.Attach(new TrackedProduct
				{
					CreatedOn = DateTime.Now,
					UserId = userId,
					ProductId = productId,
					IsTracked = true
				});
			}
			else
			{
				trackedProduct.IsTracked = true;
				uow.TrackedProducts.Update(trackedProduct);
			}

			uow.Commit();
		}

		public void Untrack(int productId, string hashedSocNetworkUserId)
		{
			var trackedProduct = GetTrackedProduct(productId, GetUserIdByHashedId(hashedSocNetworkUserId));

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			trackedProduct.IsTracked = false;
			uow.TrackedProducts.Update(trackedProduct);
			uow.Commit();
		}

		public void Remove(int productId, string hashedSocNetworkUserId)
		{
			var trackedProduct = GetTrackedProduct(productId, GetUserIdByHashedId(hashedSocNetworkUserId));

			if (trackedProduct == null)
			{
				throw new ArgumentException("arguments");
			}

			uow.TrackedProducts.Detach(trackedProduct);
			uow.Commit();
		}

		private int GetUserIdByHashedId(string hashedSocNetworkUserId)
		{
			var socialId = hashService.Decrypt(hashedSocNetworkUserId);
			var result = uow.UserRepository.FindBy(x => x.SocialId == socialId);
			return result.Id;
		}

		private TrackedProduct GetTrackedProduct(int productId, int userId)
		{
			var trackedProduct = uow.TrackedProducts
				.FindBy(x => x.ProductId == productId && x.UserId == userId);

			return trackedProduct;
		}
	}
}
