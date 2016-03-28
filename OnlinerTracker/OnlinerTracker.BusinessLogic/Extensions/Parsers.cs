using System;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Enteties;
using Product = OnlinerTracker.DataAccess.Enteties.Product;
using ProductTracking = OnlinerTracker.DataAccess.Enteties.ProductTracking;

namespace OnlinerTracker.BusinessLogic.Extensions
{
	public static class Parsers
	{
		public static Product ToEntity(this Models.Product product, DateTime? createdOn = null)
		{
			return new Product
			{
				Id = product.Id,
				CreatedOn = createdOn ?? DateTime.Now,
				FullName = product.FullName,
				Description = product.Description,
				MinPrice = product.Price?.Min ?? 0,
				MaxPrice = product.Price?.Max ?? 0,
				IconImageUrl = product.Image?.Icon,
				HeaderImageUrl = product.Image?.Header
			};
		}

		public static User ToEntity(this UserInfo user, int? id = null, DateTime? createdOn = null)
		{
			return new User
			{
				Id = id ?? user.Id,
				CreatedOn = createdOn ?? DateTime.Now,
				FirstName = user.FirstName,
				SocialId = user.SocialNetworkUserId,
				Email = user.Email
			};
		}

		public static UserInfo ToModel(this User user)
		{
			return new UserInfo
			{
				Id = user.Id,
				FirstName = user.FirstName,
				Email = user.Email,
				UserSettings = new Models.UserSettings
				{
					PreferedTime = user.UserSettings?.PreferedTime ?? TimeSpan.Zero
				}
			};
		}

		public static Models.Product ToModel(this ProductTracking productTracking)
		{
			return new Models.Product
			{
				Id = productTracking.ProductId,
				FullName = productTracking.Product.FullName,
				Description = productTracking.Product.Description,
				IsAdded = true,
				IsTracked = productTracking.Enabled,
				Image = new Image { Icon = productTracking.Product.IconImageUrl, Header = productTracking.Product.HeaderImageUrl },
				Price = new Price { Min = productTracking.Product.MinPrice, Max = productTracking.Product.MaxPrice },
				Increase = productTracking.Increase,
				Decrease = productTracking.Decrease
			};
		}
	}
}