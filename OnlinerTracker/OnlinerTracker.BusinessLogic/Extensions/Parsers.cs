using System;
using OnlinerTracker.BusinessLogic.Models.Onliner;
using OnlinerTracker.BusinessLogic.Models.User;
using OnlinerTracker.DataAccess.Enteties;
using Product = OnlinerTracker.DataAccess.Enteties.Product;

namespace OnlinerTracker.BusinessLogic.Extensions
{
	public static class Parsers
	{
		public static Product ToEntity(this Models.Onliner.Product product)
		{
			return new Product
			{
				Id = product.Id,
				CreatedAt = product.CreatedAt,
				FullName = product.FullName,
				Description = product.Description,
				MinPrice = product.Price?.Min ?? 0,
				MaxPrice = product.Price?.Max ?? 0,
				IconImageUrl = product.Image?.Icon,
				HeaderImageUrl = product.Image?.Header
			};
		}

		public static User ToEntity(this UserInfo user)
		{
			return new User
			{
				Id = user.Id,
				CreatedAt = user.CreatedAt ?? DateTime.Now,
				FirstName = user.FirstName,
				SocialId = user.SocialNetworkUserId,
				Email = user.Email
			};
		}

		public static PriceHistory ToEntity(this Models.PriceHistory priceHistory)
		{
			return new PriceHistory
			{
				Id = priceHistory.Id,
				CreatedAt = priceHistory.CreatedAt,
				ProductId = priceHistory.Product.Id,
				MinPrice = priceHistory.MinPrice,
				MaxPrice = priceHistory.MaxPrice,
				Notified = priceHistory.Notifited
			};
		}

		public static Models.Onliner.Product ToModel(this Product product)
		{
			return new Models.Onliner.Product
			{
				Id = product.Id,
				CreatedAt = product.CreatedAt ?? DateTime.Now,
				FullName = product.FullName,
				Description = product.Description,
				IsAdded = true,
				Image = new Image { Icon = product.IconImageUrl, Header = product.HeaderImageUrl },
				Price = new Price { Min = product.MinPrice, Max = product.MaxPrice }
			};
		}

		public static UserInfo ToModel(this User user)
		{
			return new UserInfo
			{
				Id = user.Id,
				CreatedAt = user.CreatedAt,
				FirstName = user.FirstName,
				Email = user.Email,
				UserSettings = new Models.User.UserSettings
				{
					PreferedTime = user.UserSettings?.PreferedTime ?? TimeSpan.Zero
				}
			};
		}

		public static Models.Onliner.Product ToModel(this ProductTracking productTracking)
		{
			return new Models.Onliner.Product
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

		public static Models.PriceHistory ToModel(this PriceHistory priceHistory)
		{
			return new Models.PriceHistory
			{
				Id = priceHistory.Id,
				CreatedAt = priceHistory.CreatedAt,
				ProductId = priceHistory.ProductId,
				Product = priceHistory.Product.ToModel(),
				MinPrice = priceHistory.MaxPrice,
				MaxPrice = priceHistory.MaxPrice,
				Notifited = priceHistory.Notified
			};
		}
	}
}