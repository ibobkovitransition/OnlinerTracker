using System;
using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.User;
using OnlinerTracker.DataAccess.Interfaces;
using UserSettings = OnlinerTracker.DataAccess.Enteties.UserSettings;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
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

		public UserInfo Get(int userId)
		{
			var user = unitOfWork.UserRepository.FindBy(x => x.Id == userId);
			return user.ToModel();
		}

		public UserInfo GetBySocialId(string socialId)
		{
			var user = unitOfWork.UserRepository.FindBy(x => x.SocialId == socialId);
			return user?.ToModel();
		}

		public void Update(int userId, UserInfo userInfo)
		{
			var entity = unitOfWork.UserRepository.FindBy(x => x.Id == userId, x => x.UserSettings);
			entity.Email = userInfo.Email;

			entity.UserSettings = entity.UserSettings ?? new UserSettings
			{
				Id = userId,
				CreatedAt = DateTime.Now
			};

			entity.UserSettings.PreferedTime = userInfo.UserSettings?.PreferedTime ?? TimeSpan.Zero;
			unitOfWork.UserRepository.Update(entity);
			unitOfWork.Commit();
		}

		public string AddUser(NameValueCollection queryString, string serviceName)
		{
			var user = authService.UserInfo(queryString, serviceName);
			var isExists = unitOfWork.UserRepository.FindBy(x => x.SocialId == user.SocialNetworkUserId) != null;

			if (!isExists)
			{
				var entity = user.ToEntity();
				entity.UserSettings = new UserSettings
				{
					CreatedAt = DateTime.Now,
					PreferedTime = TimeSpan.Zero,
				};

				unitOfWork.UserRepository.Attach(entity);
				unitOfWork.Commit();
			}

			return user.SocialNetworkUserId;
		}
	}
}
