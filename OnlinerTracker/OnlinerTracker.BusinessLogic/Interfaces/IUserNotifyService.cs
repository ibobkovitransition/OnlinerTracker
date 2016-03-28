using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IUserNotifyService
	{
		void NotifyAll(IEnumerable<ProductTracking> products);
	}
}