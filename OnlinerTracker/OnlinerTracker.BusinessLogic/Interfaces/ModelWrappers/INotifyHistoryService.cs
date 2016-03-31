using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Notification;
using EntityNotifyHistory = OnlinerTracker.DataAccess.Enteties.NotifyHistory;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface INotifyHistoryService
	{
		IEnumerable<EntityNotifyHistory> GetActual();

		void Add(IEnumerable<NotifyHistory> notifyHistories);

		void Update(IEnumerable<NotifyHistory> notifyHistories);
	}
}