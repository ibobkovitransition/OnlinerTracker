﻿using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
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
				where !actualNotifications.Any(x => x.UserId == tracking.UserInfoId && x.ProductId == tracking.ProductId)
				select new NotifyHistory
				{
					CreatedAt = DateTime.Now,
					UserInfoId = tracking.UserInfoId,
					ProductId = tracking.ProductId,
					Notifited = false
				};

			notifyHistoryService.Add(result);
		}

		public void MarkAsNotifited(int intervalInMinutes)
		{
			var notifications = GetNotificationsByInterval(intervalInMinutes).Select(x =>
			{
				var temp = x;
				temp.Notifited = true;
				temp.NotifitedAt = DateTime.Now;
				return temp;
			});
			notifyHistoryService.Update(notifications);
		}

		private IEnumerable<NotifyHistory> GetNotificationsByInterval(int intervalInMinutes)
		{
			var actual = notifyHistoryService.GetActual();

			return actual.Select(x => x.ToModel()).Where(
				x =>
					GetDifference(x.UserInfo.UserSettings.PreferedTime) <= intervalInMinutes &&
					GetDifference(x.UserInfo.UserSettings.PreferedTime) > 0);
		}

		private int GetDifference(TimeSpan target)
		{
			return (int)DateTime.Now.TimeOfDay.Subtract(target).TotalMinutes;
		}
	}
}