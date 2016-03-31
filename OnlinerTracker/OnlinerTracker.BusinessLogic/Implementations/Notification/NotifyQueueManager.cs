using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyQueueManager : INotifyQueueManager
	{
		private readonly INotifyHistoryService notifyHistoryService;
		private readonly IProductTrackingService productTrackingService;

		public NotifyQueueManager(INotifyHistoryService notifyHistoryService, IProductTrackingService productTrackingService)
		{
			this.notifyHistoryService = notifyHistoryService;
			this.productTrackingService = productTrackingService;
		}

		public void Register(IEnumerable<Product> products)
		{
			var actualTrackingList = productTrackingService.GetActualByProducts(products);
			var actualNotifications = notifyHistoryService.GetActual();

			var result =
				from tracking in actualTrackingList
				where !actualNotifications.Any(x => x.UserInfoId == tracking.UserInfoId && x.ProductId == tracking.ProductId)
				select new NotifyHistory
				{
					CreatedAt = DateTime.Now,
					UserInfoId = tracking.UserInfoId,
					ProductId = tracking.ProductId,
					Notifited = false
				};

			notifyHistoryService.Add(result);
		}
	}
}