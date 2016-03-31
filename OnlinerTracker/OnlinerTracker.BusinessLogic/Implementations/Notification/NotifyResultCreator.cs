using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.DataAccess.Interfaces;
using EntityNotifyHistory = OnlinerTracker.DataAccess.Enteties.NotifyHistory;
using EntityPricerHistory = OnlinerTracker.DataAccess.Enteties.PriceHistory;
using EntityProductTracking = OnlinerTracker.DataAccess.Enteties.ProductTracking;
using EntityUser = OnlinerTracker.DataAccess.Enteties.User;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyResultCreator : INotifyResultCreator
	{
		private readonly INotifyHistoryService notifyHistoryService;
		private readonly IRepository<EntityNotifyHistory> notifyHistoryRepository;

		public NotifyResultCreator(
			INotifyHistoryService notifyHistoryService,
			IRepository<EntityNotifyHistory> notifyHistoryRepository)
		{
			this.notifyHistoryService = notifyHistoryService;
			this.notifyHistoryRepository = notifyHistoryRepository;
		}

		public IEnumerable<NotifyResult> Create(int intervalInMinutes)
		{
			var groupResult = GetNotifyProductGroup(GetNotificationsByInterval(intervalInMinutes));

			return GetNotifyResults(groupResult);
		}

		private static IEnumerable<NotifyResult> GetNotifyResults(IEnumerable<IGrouping<EntityUser, NotifyProduct>> groupResult)
		{
			return groupResult.Select(x => new NotifyResult
			{
				UserInfo = x.Key.ToModel(),
				NotifyProducts = x
			});
		}

		private IEnumerable<EntityNotifyHistory> GetNotificationsByInterval(int intervalInMinutes)
		{
			var actual = notifyHistoryService.GetActual();

			return actual.Where(
				x =>
					GetDifference(x.User.UserSettings.PreferedTime) <= intervalInMinutes &&
					GetDifference(x.User.UserSettings.PreferedTime) > 0);
		}

		private IEnumerable<IGrouping<EntityUser, NotifyProduct>> GetNotifyProductGroup(IEnumerable<EntityNotifyHistory> histories)
		{
			var group = histories.GroupBy(x => x.User, x =>
			{
				var priceHistory = GetPriceHistory(x.Product.PriceHistory);
				var productTracking = GetProductTracking(x.Product.ProductTracking, x.ProductId);

				return new NotifyProduct
				{
					Product = x.Product.ToModel(),
					PriceHistory = priceHistory.ToModel(),
					Increase = productTracking.Increase,
					Decrease = productTracking.Decrease
				};
			}, new EntityUserComparer());

			return group;
		}

		private EntityPricerHistory GetPriceHistory(ICollection<EntityPricerHistory> histories)
		{
			return histories.OrderBy(x => x.CreatedAt).Last();
		}

		private EntityProductTracking GetProductTracking(ICollection<EntityProductTracking> productTrackings, int productId)
		{
			return productTrackings.First(x => x.ProductId == productId);
		}

		private int GetDifference(TimeSpan target)
		{
			return (int)DateTime.Now.TimeOfDay.Subtract(target).TotalMinutes;
		}
	}
}