using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.BusinessLogic.Implementations.Tracking
{
	public class NotifyScheduleService : INotifyScheduleService
	{
		private readonly IProductTrackingService productTrackingService;

		public NotifyScheduleService(IProductTrackingService productTrackingService)
		{
			this.productTrackingService = productTrackingService;
		}

		public void Execute()
		{
			var result = NotifyResults().Where(x => x.NotifyProducts.Any());
			// TODO: при получении, маркировать поле isNotified в true
			// т.к. пользователи будут получать одну и туже инфу если никаких обновлений не произошло

			foreach (var notifyResult in result)
			{
				Debug.WriteLine(notifyResult);
			}
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
				   where notifyProduct.CreatedAt <= lastLoggedPrice.CreatedAt

				   select new NotifyProduct
				   {
					   Product = notifyProduct.Product.ToModel(),
					   MinPrice = lastLoggedPrice.MinPrice,
					   MaxPrice = lastLoggedPrice.MaxPrice
				   };
		}
	}
}