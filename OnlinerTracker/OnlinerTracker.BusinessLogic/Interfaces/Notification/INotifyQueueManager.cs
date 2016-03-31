using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Interfaces.Notification
{
	public interface INotifyQueueManager
	{
		void Register(IEnumerable<Product> products);
	}
}