using OnlinerTracker.BusinessLogic.Interfaces.Notification;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyScheduleService : INotifyScheduleService
	{
		private readonly INotifyService notifyService;
		private readonly INotifyResultCreator notifyResultCreator;
		private readonly INotifyQueueManager notifyQueueManager;
		private readonly object syncRoot = new object();

		public NotifyScheduleService(
			INotifyService notifyService,
			INotifyResultCreator notifyResultCreator,
			INotifyQueueManager notifyQueueManager)
		{
			this.notifyService = notifyService;
			this.notifyResultCreator = notifyResultCreator;
			this.notifyQueueManager = notifyQueueManager;
		}

		public void Execute()
		{
			lock (syncRoot)
			{
				var intervalInMinutes = 10;
				var notifyResults = notifyResultCreator.Create(intervalInMinutes);
				notifyService.Notify(notifyResults);
				notifyQueueManager.MarkAsNotifited(intervalInMinutes);
			}
		}
	}
}