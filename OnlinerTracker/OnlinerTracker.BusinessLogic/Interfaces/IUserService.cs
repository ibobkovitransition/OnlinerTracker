using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IUserService
	{
		ISocNetworkAuthService AuthService { get; }

		void AuthUser(UserInfo user);
	}
}
