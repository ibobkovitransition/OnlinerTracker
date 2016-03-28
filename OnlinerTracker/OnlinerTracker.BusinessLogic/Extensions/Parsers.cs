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
				CreatedOn = product.CreatedOn,
				FullName = product.FullName,
				Description = product.Description,
				MinPrice = product.Price?.Min ?? 0,
				MaxPrice = product.Price?.Max ?? 0,
				IconImageUrl = product.Image?.Icon,
				HeaderImageUrl = product.Image?.Header
			};
		}

		public static User ToEntity(this Models.User.UserInfo user)
		{
			return new User
			{
				Id = user.Id,
				CreatedOn = user.CreatedOn,
				FirstName = user.FirstName,
				SocialId = user.SocialNetworkUserId,
				Email = user.Email
			};
		}

		public static ProductPriceHistory ToEntity(this Models.ProductPriceHistory productPriceHistory)
		{
			return new ProductPriceHistory
			{
				Id = productPriceHistory.Id,
				CreatedOn = productPriceHistory.CreatedOn,
				ProductId = productPriceHistory.Product.Id,
				MinPrice = productPriceHistory.MinPrice,
				MaxPrice = productPriceHistory.MaxPrice
			};
		}

		public static Models.Onliner.Product ToModel(this Product product)
		{
			return new Models.Onliner.Product
			{
				Id = product.Id,
				CreatedOn = product.CreatedOn,
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
	}
}