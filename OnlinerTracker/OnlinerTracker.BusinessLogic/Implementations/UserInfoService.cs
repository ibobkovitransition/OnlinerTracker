using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class UserInfoService : IUserInfoService
	{
		private readonly IUnitOfWork unitOfWOrk;

		public UserInfoService(IUnitOfWork unitOfWOrk)
		{
			this.unitOfWOrk = unitOfWOrk;
		}

		public UserInfo UserInfo(int userId)
		{
			var user = unitOfWOrk.UserRepository.FindBy(x => x.Id == userId);
			return user.ToModel();
		}
	}
}