using System.Collections.Generic;
using System.Linq;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.DataAccess.Interfaces;
using NotifyHistory = OnlinerTracker.DataAccess.Enteties.NotifyHistory;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class NotifyHistoryService : INotifyHistoryService
	{
		private readonly IRepository<NotifyHistory> notifyHistoryRepository;

		public NotifyHistoryService(IRepository<NotifyHistory> notifyHistoryRepository)
		{
			this.notifyHistoryRepository = notifyHistoryRepository;
		}

		public IEnumerable<Models.Notification.NotifyHistory> Get()
		{
			return notifyHistoryRepository.GetEntities().Select(x => x.ToModel());
		}

		public void Add(Models.Notification.NotifyHistory notifyHistory)
		{
			notifyHistoryRepository.Attach(notifyHistory.ToEntity());
			notifyHistoryRepository.Commit();
		}

		public void Update(Models.Notification.NotifyHistory notifyHistory)
		{
			notifyHistoryRepository.Update(notifyHistory.ToEntity());
			notifyHistoryRepository.Commit();
		}

		public void Update(IEnumerable<Models.Notification.NotifyHistory> notifyHistories)
		{
			foreach (var notifyHistory in notifyHistories)
			{
				notifyHistoryRepository.Update(notifyHistory.ToEntity());
			}
			notifyHistoryRepository.Commit();
		}
	}
}