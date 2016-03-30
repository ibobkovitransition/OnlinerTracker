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
			return null;
			//from item in productTrackingService.Get()
			//let lastLogged = (from history in item.Product.PriceHistory
			//				  where !history.Notified && (history.CreatedAt >= item.CreatedAt)
			//				  orderby history.CreatedAt
			//				  select history).LastOrDefault()

			//where
			//	item.Enabled &&
			//	(item.Decrease || item.Increase) &&
			//	lastLogged != null

			//group new
			//{
			//	User = item.User,
			//	NotifyProduct = new NotifyProduct
			//	{
			//		Product = item.Product.ToModel(),
			//		Decrease = item.Decrease,
			//		Increase = item.Increase,
			//		PriceHistory = lastLogged.ToModel()
			//	}
			//} by item.User.Id into productsGroup

			//select new NotifyResult
			//{
			//	UserInfo = productsGroup.Select(x => x.User).First().ToModel(),
			//	NotifyProducts = productsGroup.Select(x => x.NotifyProduct)
			//};
		}
	}
}