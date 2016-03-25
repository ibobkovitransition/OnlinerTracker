using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class UserNotificationService : IUserNotificationService
	{
		private readonly INotifyMessageCreatorService notifyMessageCreatorService;
		private readonly IEmailProvider emailProvider;

		public UserNotificationService(INotifyMessageCreatorService notifyMessageCreatorService, IEmailProvider emailProvider)
		{
			this.notifyMessageCreatorService = notifyMessageCreatorService;
			this.emailProvider = emailProvider;
		}

		public void Notify(IEnumerable<ProductTracking> products)
		{
			// формиурем очередь
			// дробим
			CreateNotifyQueue();

			// производим обход очереди
			// создаем сообщение с помощью
			emailProvider.Send(notifyMessageCreatorService.CreateMessage(/*первый элемент из коллекции*/ null, products));
			throw new System.NotImplementedException();
		}

		// очередь не в смысле структура данных
		private void CreateNotifyQueue()
		{
			/// можно обойтись и linq-ом
			/// TODO: формирование структуры типа: Dictionary<userId, Product> notifyQueue
		}

		private void CreateNotifyMessage()
		{
			/// TODO: формирование сообщения для каждого пользователя
		}
	}
}