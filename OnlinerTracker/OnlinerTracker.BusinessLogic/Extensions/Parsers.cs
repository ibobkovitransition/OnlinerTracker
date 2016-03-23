using System;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Enteties;
using Product = OnlinerTracker.DataAccess.Enteties.Product;

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

		public static User ToEntity(this UserInfo user, DateTime? createdOn = null)
		{
			return new User
			{
				SocialId = user.UserId,
				FirstName = user.FirstName,
				CreatedOn = createdOn ?? DateTime.Now
			};
		}

		public static UserInfo ToModel(this User user)
		{
			return new UserInfo
			{
				FirstName = user.FirstName,
				Email = user.Email,
				UserSettings = new Models.UserSettings
				{
					SelectedCurrency = user.UserSettings?.SelectedCurrency,
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
				Image = new Image {Icon = productTracking.Product.IconImageUrl, Header = productTracking.Product.HeaderImageUrl},
				Price = new Price {Min = productTracking.Product.MinPrice, Max = productTracking.Product.MaxPrice},
				Increase = productTracking.Increase,
				Decrease = productTracking.Decrease
			};
		}
	}
}