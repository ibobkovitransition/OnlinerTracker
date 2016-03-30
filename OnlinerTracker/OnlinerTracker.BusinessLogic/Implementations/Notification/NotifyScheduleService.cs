using System.Collections.Generic;
using System.Linq;
using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;
using PriceHistory = OnlinerTracker.BusinessLogic.Models.PriceHistory;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyScheduleService : INotifyScheduleService, IJob
	{
		private readonly INotifyService notifyService;
		private readonly IPriceHistoryService priceHistoryService;
		private readonly INotifyResultCreator notifyResultCreator;
		private readonly object syncRoot = new object();

		public NotifyScheduleService(INotifyService notifyService, IPriceHistoryService priceHistoryService, INotifyResultCreator notifyResultCreator)
		{
			this.notifyService = notifyService;
			this.priceHistoryService = priceHistoryService;
			this.notifyResultCreator = notifyResultCreator;
		}

		public void Execute()
		{
			lock (syncRoot)
			{
				// починить рассылку
				var notifyResults = notifyResultCreator.Create().Where(x => x.NotifyProducts.Any());
				notifyService.Notify(notifyResults);
				MarkAsNotifited(notifyResults);
			}
		}

		// выпилить
		private void MarkAsNotifited(IEnumerable<NotifyResult> notifyResults)
		{
			var result = new List<PriceHistory>();

			// с linq нормально не получилось
			foreach (var notifyResult in notifyResults)
			{
				result.AddRange(notifyResult.NotifyProducts.Select(x => x.PriceHistory));
			}

			priceHistoryService.Update(result);
		}
	}
}