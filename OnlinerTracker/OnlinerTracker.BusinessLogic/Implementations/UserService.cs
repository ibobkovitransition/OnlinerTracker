using System;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork uow;

		public ISocNetworkAuthService AuthService { get; }

		public UserService(IUnitOfWork uow, ISocNetworkAuthService authService)
		{
			this.uow = uow;
			AuthService = authService;
		}

		public void AuthUser(UserInfo user)
		{
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
		}
	}
}
