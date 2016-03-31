using System;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.BusinessLogic.Models.Onliner;
using OnlinerTracker.BusinessLogic.Models.User;
using EntityProduct = OnlinerTracker.DataAccess.Enteties.Product;
using EntityProductTracking = OnlinerTracker.DataAccess.Enteties.ProductTracking;
using EntityUser = OnlinerTracker.DataAccess.Enteties.User;
using EntityPriceHistory = OnlinerTracker.DataAccess.Enteties.PriceHistory;
using EntityNotifyHistory = OnlinerTracker.DataAccess.Enteties.NotifyHistory;
using EntityUserSettings = OnlinerTracker.DataAccess.Enteties.UserSettings;

namespace OnlinerTracker.BusinessLogic.Extensions
{
	public static class Parsers
	{
		#region Product
		public static EntityProduct ToEntity(this Product product)
		{
			return new EntityProduct
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

		public static Product ToModel(this EntityProduct product)
		{
			return new Product
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

		public static Product ToProduct(this EntityProductTracking productTracking)
		{
			return new Product
			{
				Id = productTracking.Product.Id,
				CreatedAt = productTracking.Product.CreatedAt,
				FullName = productTracking.Product.FullName,
				Description = productTracking.Product.Description,

				Price = new Price
				{
					Min = productTracking.Product?.MinPrice ?? 0,
					Max = productTracking.Product?.MaxPrice ?? 0
				},

				Image = new Image
				{
					Icon = productTracking.Product.IconImageUrl,
					Header = productTracking.Product.HeaderImageUrl
				},

				IsAdded = true,
				IsTracked = productTracking.Enabled,
				Increase = productTracking.Increase,
				Decrease = productTracking.Decrease,
			};
		}
		#endregion

		#region ProductTracking
		public static EntityProductTracking ToEntity(this ProductTracking productTracking)
		{
			return new EntityProductTracking
			{
				Id = productTracking.Id,
				CreatedAt = productTracking.CreatedAt,
				ProductId = productTracking.ProductId,
				//Product = productTracking.Product?.ToEntity(),
				UserId = productTracking.UserInfoId,
				//User = productTracking.UserInfo?.ToEntity(),
				Enabled = productTracking.Enabled,
				Increase = productTracking.Increase,
				Decrease = productTracking.Decrease
			};
		}

		public static ProductTracking ToModel(this EntityProductTracking productTracking)
		{
			return new ProductTracking
			{
				Id = productTracking.Id,
				CreatedAt = productTracking.CreatedAt,
				ProductId = productTracking.ProductId,
				Product = productTracking.Product?.ToModel(),
				UserInfoId = productTracking.UserId,
				UserInfo = productTracking.User?.ToModel(),
				Enabled = productTracking.Enabled,
				Increase = productTracking.Increase,
				Decrease = productTracking.Decrease
			};
		}
		#endregion

		#region UserInfo \ User
		public static EntityUser ToEntity(this UserInfo user)
		{
			return new EntityUser
			{
				Id = user.Id,
				CreatedAt = user.CreatedAt ?? DateTime.Now,
				FirstName = user.FirstName,
				SocialId = user.SocialNetworkUserId,
				Email = user.Email,
				UserSettings = user.UserSettings?.ToEntity() ?? new EntityUserSettings()
			};
		}

		public static UserInfo ToModel(this EntityUser user)
		{
			return new UserInfo
			{
				Id = user.Id,
				CreatedAt = user.CreatedAt,
				FirstName = user.FirstName,
				SocialNetworkUserId = user.SocialId,
				Email = user.Email,
				UserSettings = user.UserSettings?.ToModel() ?? new UserSettings()
			};
		}
		#endregion

		#region UserSettings

		public static EntityUserSettings ToEntity(this UserSettings settings)
		{
			return new EntityUserSettings
			{
				Id = settings.Id,
				CreatedAt = settings.CreatedAt,
				PreferedTime = settings.PreferedTime,
			};
		}

		public static UserSettings ToModel(this EntityUserSettings settings)
		{
			return new UserSettings
			{
				Id = settings.Id,
				CreatedAt = settings.CreatedAt,
				PreferedTime = settings.PreferedTime
			};
		}
		#endregion

		#region PriceHistory
		public static EntityPriceHistory ToEntity(this PriceHistory priceHistory)
		{
			return new EntityPriceHistory
			{
				Id = priceHistory.Id,
				CreatedAt = priceHistory.CreatedAt,
				ProductId = priceHistory.Product.Id,
				//Product = priceHistory.Product?.ToEntity(),
				MinPrice = priceHistory.MinPrice,
				MaxPrice = priceHistory.MaxPrice,
			};
		}

		public static PriceHistory ToModel(this EntityPriceHistory priceHistory)
		{
			return new PriceHistory
			{
				Id = priceHistory.Id,
				CreatedAt = priceHistory.CreatedAt,
				ProductId = priceHistory.ProductId,
				Product = priceHistory.Product?.ToModel(),
				MinPrice = priceHistory.MaxPrice,
				MaxPrice = priceHistory.MaxPrice
			};
		}
		#endregion

		#region NotifyHistory
		public static EntityNotifyHistory ToEntity(this NotifyHistory notifyHistory)
		{
			return new EntityNotifyHistory
			{
				Id = notifyHistory.Id,
				CreatedAt = notifyHistory.CreatedAt,
				UserId = notifyHistory.UserInfoId,
				//User = notifyHistory.UserInfo?.ToEntity(),
				ProductId = notifyHistory.ProductId,
				//Product = notifyHistory.Product?.ToEntity(),
				Notifited = notifyHistory.Notifited,
				NotifitedAt = notifyHistory.NotifitedAt
			};
		}

		public static NotifyHistory ToModel(this EntityNotifyHistory notifyHistory)
		{
			return new NotifyHistory
			{
				Id = notifyHistory.Id,
				CreatedAt = notifyHistory.CreatedAt,
				UserInfoId = notifyHistory.UserId,
				UserInfo = notifyHistory.User?.ToModel(),
				ProductId = notifyHistory.ProductId,
				Product = notifyHistory.Product?.ToModel(),
				Notifited = notifyHistory.Notifited,
				NotifitedAt = notifyHistory.NotifitedAt
			};
		}
		#endregion
	}
}