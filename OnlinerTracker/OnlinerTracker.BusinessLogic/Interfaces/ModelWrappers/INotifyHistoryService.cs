using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface INotifyHistoryService
	{
		IEnumerable<NotifyHistory> Get();

		void Add(NotifyHistory notifyHistory);

		void Update(NotifyHistory notifyHistory);

		void Update(IEnumerable<NotifyHistory> notifyHistories);
	}
}