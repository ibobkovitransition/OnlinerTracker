using System;
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
				var sendOn = CurrentTime;
				var notifyResults = notifyResultCreator.Create(sendOn);
				notifyService.Notify(notifyResults);
				notifyQueueManager.MarkAsNotifited(sendOn);
			}
		}

		private TimeSpan CurrentTime
		{
			get
			{
				var now = DateTime.Now.TimeOfDay;
				return new TimeSpan(now.Ticks - (now.Ticks % 600000000));
			}
		}
	}
}