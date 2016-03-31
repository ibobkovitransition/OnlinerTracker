using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.Notification;
using OnlinerTracker.DataAccess.Interfaces;
using EntityNotifyHistory = OnlinerTracker.DataAccess.Enteties.NotifyHistory;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class NotifyHistoryService : INotifyHistoryService
	{
		private readonly IRepository<EntityNotifyHistory> notifyHistoryRepository;

		public NotifyHistoryService(IRepository<EntityNotifyHistory> notifyHistoryRepository)
		{
			this.notifyHistoryRepository = notifyHistoryRepository;
		}

		public IEnumerable<NotifyHistory> GetActual()
		{
			return notifyHistoryRepository.GetEntities(
				x => !x.Notifited,
				x => x.User,
				x => x.Product).Select(x => x.ToModel());
		}

		public void Add(IEnumerable<NotifyHistory> notifyHistories)
		{
			foreach (var notifyHistory in notifyHistories)
			{
				notifyHistoryRepository.Attach(notifyHistory.ToEntity());
			}
			notifyHistoryRepository.Commit();
		}
	}
}