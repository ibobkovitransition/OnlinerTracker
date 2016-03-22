
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IUserInfoService
	{
		UserInfo UserInfo(int userId);
	}
}