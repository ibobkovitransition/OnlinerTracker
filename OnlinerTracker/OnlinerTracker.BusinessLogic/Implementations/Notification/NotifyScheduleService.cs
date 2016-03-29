using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.DataAccess.Enteties;
using PriceHistory = OnlinerTracker.BusinessLogic.Models.PriceHistory;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyScheduleService : INotifyScheduleService
	{
		private readonly IProductTrackingService productTrackingService;
		private readonly INotifyService notifyService;
		private readonly IPriceHistoryService priceHistoryService;

		public NotifyScheduleService(IProductTrackingService productTrackingService, INotifyService notifyService, IPriceHistoryService priceHistoryService)
		{
			this.productTrackingService = productTrackingService;
			this.notifyService = notifyService;
			this.priceHistoryService = priceHistoryService;
		}

		public void Execute()
		{
			var notifyResults = NotifyResults().Where(x => x.NotifyProducts.Any());
			notifyService.Notify(notifyResults);
			MarkAsNotifited(notifyResults);
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

		private void MarkAsNotifited(IEnumerable<NotifyResult> notifyResults)
		{
			var result = new List<PriceHistory>();

			// с linq нормально не получилось
			foreach (var notifyResult in notifyResults)
			{
				result.AddRange(notifyResult.NotifyProducts.Select(x =>
				{
					var temp = x.PriceHistory;
					temp.Notifited = true;
					return temp;
				}));
			}

			priceHistoryService.Update(result);
		}
	}
}