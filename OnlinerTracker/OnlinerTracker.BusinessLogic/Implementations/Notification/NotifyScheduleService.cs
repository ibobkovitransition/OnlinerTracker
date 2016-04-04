using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyScheduleService : INotifyScheduleService
	{
		private readonly INotifyService notifyService;
		private readonly INotifyResultCreator notifyResultCreator;
		private readonly INotifyQueueManager notifyQueueManager;
		private readonly IDeliveryConfig config;
		private readonly object syncRoot = new object();

		public NotifyScheduleService(
			INotifyService notifyService,
			INotifyResultCreator notifyResultCreator,
			INotifyQueueManager notifyQueueManager,
			IDeliveryConfig config)
		{
			this.notifyService = notifyService;
			this.notifyResultCreator = notifyResultCreator;
			this.notifyQueueManager = notifyQueueManager;
			this.config = config;
		}

		public void Execute()
		{
			lock (syncRoot)
			{
				var intervalInMinutes = config.DeliveryInterval;
				var notifyResults = notifyResultCreator.Create(intervalInMinutes);
				notifyService.Notify(notifyResults);
				notifyQueueManager.MarkAsNotifited(intervalInMinutes);
			}
		}
	}
}