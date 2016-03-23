using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly ISocialNetworkAuthService authService;

		public UserService(IUnitOfWork unitOfWork, ISocialNetworkAuthService authService)
		{
			this.unitOfWork = unitOfWork;
			this.authService = authService;
		}

		public UserInfo GetUserInfo(int userId)
		{
			var user = unitOfWork.UserRepository.FindBy(x => x.Id == userId);
			return user.ToModel();
		}

		public string AddUser(NameValueCollection queryString, string serviceName)
		{
			var user = authService.UserInfo(queryString, serviceName);
			var isExists = unitOfWork.UserRepository.FindBy(x => x.SocialId == user.UserId) != null;

			if (!isExists)
			{
				unitOfWork.UserRepository.Attach(user.ToEntity());
				unitOfWork.Commit();
			}

			return user.UserId;
		}
	}
}
