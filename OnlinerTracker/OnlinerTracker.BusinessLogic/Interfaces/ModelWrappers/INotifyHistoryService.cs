using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface INotifyHistoryService
	{
		IEnumerable<NotifyHistory> GetPendingNotifications();

		void Add(NotifyHistory notifyHistory);

		void Add(IEnumerable<NotifyHistory> hotNotifyHistories);

		void Update(NotifyHistory notifyHistory);

		void Update(IEnumerable<NotifyHistory> notifyHistories);
	}
}