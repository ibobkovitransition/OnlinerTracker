using System;
using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Notification;
using EntityNotifyHistory = OnlinerTracker.DataAccess.Enteties.NotifyHistory;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface INotifyHistoryService
	{
		IEnumerable<NotifyHistory> GetActual();

		IEnumerable<EntityNotifyHistory> GetActualByTime(TimeSpan sendOn); 

		void Add(IEnumerable<NotifyHistory> notifyHistories);

		void Update(IEnumerable<NotifyHistory> notifyHistories);
	}
}