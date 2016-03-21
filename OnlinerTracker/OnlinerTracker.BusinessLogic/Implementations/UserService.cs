using System;
using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly ISocNetworkAuthService authService;

		public UserService(IUnitOfWork unitOfWork, ISocNetworkAuthService authService)
		{
			this.unitOfWork = unitOfWork;
			this.authService = authService;
		}

		public string AddUser(NameValueCollection queryString, string serviceName)
		{
			var user = authService.UserInfo(queryString, serviceName);
			var isExists = unitOfWork.UserRepository.FindBy(x => x.SocialId == user.UserId) != null;

			if (!isExists)
			{
				unitOfWork.UserRepository.Attach(new User
				{
					SocialId = user.UserId,
					FirstName = user.FirstName,
					PhotoUri = user.PhotoUri,
					CreatedOn = DateTime.Now
				});
				unitOfWork.Commit();
			}

			return user.UserId;
		}
	}
}
