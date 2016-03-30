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

		public void RegisterByProducts(IEnumerable<Product> products)
		{
			var userIds = productTrackingService.Get(products)
				.Where(x => x.Enabled && (x.Increase || x.Decrease))
				.Select(x => x.UserInfoId)
				.Distinct();

			var pendingNotifications = notifyHistoryService.GetPendingNotifications();

			var idsToNotify = userIds.Where(
				x => !pendingNotifications.Select(
					c => c.UserInfoId).Contains(x)).Distinct();

			notifyHistoryService.Add(idsToNotify.Select(userId => new NotifyHistory
			{
				CreatedAt = DateTime.Now,
				Notifited = false,
				UserInfoId = userId
			}));
		}
	}
}