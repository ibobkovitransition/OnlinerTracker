using System;
using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyResultCreator : INotifyResultCreator
	{
		private readonly INotifyHistoryService notifyHistoryService;

		public NotifyResultCreator(INotifyHistoryService notifyHistoryService)
		{
			this.notifyHistoryService = notifyHistoryService;
		}

		public IEnumerable<NotifyResult> Create(TimeSpan sendOn)
		{
			return NotifyResults(sendOn);
		}

		private IEnumerable<NotifyResult> NotifyResults(TimeSpan sendOn)
		{
			return
				from item in notifyHistoryService.GetActualByTime(sendOn)
				let priceHistory = item.Product.PriceHistory.OrderBy(x => x.CreatedAt).Last()
				let productTracking = item.Product.ProductTracking.First(x => x.ProductId == item.ProductId)

				group new
				{
					User = item.User,
					NotifyProduct = new NotifyProduct
					{
						Product = item.Product.ToModel(),
						Increase = productTracking.Increase,
						Decrease = productTracking.Decrease,
						PriceHistory = priceHistory.ToModel()
					}
				}

				by item.UserId into notifyProducts

				select new NotifyResult
				{
					UserInfo = notifyProducts.Select(x => x.User).First().ToModel(),
					NotifyProducts = notifyProducts.Select(x => x.NotifyProduct)
				};
		}
	}
}