using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyResultCreator : INotifyResultCreator
	{
		private readonly IProductTrackingService productTrackingService;

		public NotifyResultCreator(IProductTrackingService productTrackingService)
		{
			this.productTrackingService = productTrackingService;
		}

		public IEnumerable<NotifyResult> Create()
		{
			return NotifyResults();
		}

		private IEnumerable<NotifyResult> NotifyResults()
		{
			return from item in productTrackingService.Get()
				   where
					   item.Enabled &&
					   (item.Decrease || item.Increase) &&
					   item.Product.PriceHistory.Any()
				   group item by item.User into productsGroup

				   select new NotifyResult
				   {
					   UserInfo = productsGroup.Key.ToModel(),
					   NotifyProducts = NotifyProducts(productsGroup)
				   };
		}

		private IEnumerable<NotifyProduct> NotifyProducts(IGrouping<User, ProductTracking> productsGroup)
		{
			return from notifyProduct in productsGroup
				   let lastLoggedPrice = notifyProduct.Product.PriceHistory.OrderBy(x => x.CreatedAt).Last()
				   where
					   notifyProduct.CreatedAt <= lastLoggedPrice.CreatedAt &&
					   !lastLoggedPrice.Notified

				   select new NotifyProduct
				   {
					   Product = notifyProduct.Product.ToModel(),
					   PriceHistory = lastLoggedPrice.ToModel(),
					   Decrease = notifyProduct.Decrease,
					   Increase = notifyProduct.Increase
				   };
		}
	}
}