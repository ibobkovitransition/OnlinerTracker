using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
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
			//var pt = productTrackingService.Get();

			var registered = notifyHistoryService.Get();
			//notifyHistoryService.Add();
			//throw new System.NotImplementedException();
		}
	}
}