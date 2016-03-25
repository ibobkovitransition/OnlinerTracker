using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface INotifyMessageCreatorService
	{
		string CreateMessage(UserInfo userInfo, IEnumerable<ProductTracking> products);
	}
}