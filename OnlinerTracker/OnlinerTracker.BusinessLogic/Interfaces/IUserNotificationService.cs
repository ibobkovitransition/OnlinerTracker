using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IUserNotificationService
	{
		void Notify(IEnumerable<ProductTracking> products);
	}
}