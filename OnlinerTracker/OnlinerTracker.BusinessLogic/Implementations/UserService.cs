using System;
using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork uow;
		private readonly ISocNetworkAuthService authService;

		public UserService(IUnitOfWork uow, ISocNetworkAuthService authService)
		{
			this.uow = uow;
			this.authService = authService;
		}

		public string AddUser(NameValueCollection queryString, string serviceName)
		{
			var user = authService.GetUserInfo(queryString, serviceName);
			var isUserExists = uow.UserRepository.FindBy(x => x.UserId == user.UserId) != null;

			if (!isUserExists)
			{
				uow.UserRepository.Create(new User
				{
					UserId = user.UserId,
					FirstName = user.FirstName,
					PhotoUri = user.PhotoUri,
					CreatedOn = DateTime.Now
				});
				uow.Commit();
			}

			return user.UserId;
		}
	}
}
