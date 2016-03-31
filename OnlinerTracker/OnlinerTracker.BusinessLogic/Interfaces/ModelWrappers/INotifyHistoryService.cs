using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface INotifyHistoryService
	{
		IEnumerable<NotifyHistory> GetActual();

		void Add(IEnumerable<NotifyHistory> hotNotifyHistories);
	}
}