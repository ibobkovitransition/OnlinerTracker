﻿using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyScheduleService : INotifyScheduleService
	{
		private readonly IProductTrackingService productTrackingService;
		private readonly INotifyService notifyService;

		public NotifyScheduleService(IProductTrackingService productTrackingService, INotifyService notifyService)
		{
			this.productTrackingService = productTrackingService;
			this.notifyService = notifyService;
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
					   MinPrice = lastLoggedPrice.MinPrice,
					   MaxPrice = lastLoggedPrice.MaxPrice,
					   Decrease = notifyProduct.Decrease,
					   Increase = notifyProduct.Increase
				   };
		}

		private void MarkAsNotifited(IEnumerable<NotifyResult> notifyResults)
		{
			// Зову нужный сервис и устанавливаю флаги в true
		}
	}
}