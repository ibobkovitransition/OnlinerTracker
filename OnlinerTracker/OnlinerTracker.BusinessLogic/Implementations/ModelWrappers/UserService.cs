using System;
using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.User;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;
using EntityUserSettings = OnlinerTracker.DataAccess.Enteties.UserSettings;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> userRepository;
		private readonly IRepository<EntityUserSettings> userSettingsRepository;
		private readonly ISocialNetworkAuthService authService;

		public UserService(
			ISocialNetworkAuthService authService, 
			IRepository<User> userRepository, 
			IRepository<EntityUserSettings> userSettingsRepository)
		{
			this.authService = authService;
			this.userRepository = userRepository;
			this.userSettingsRepository = userSettingsRepository;
		}

		public UserInfo Get(int userId)
		{
			return userRepository.FindBy(
				x => x.Id == userId).ToModel();
		}

		public UserInfo GetBySocialId(string socialId)
		{
			return userRepository.FindBy(
				x => x.SocialId == socialId,
				x => x.UserSettings)?.ToModel();
		}

		public void Update(UserInfo userInfo)
		{
			var entity = userRepository.FindBy(x => x.Id == userInfo.Id, x => x.UserSettings);
			entity.Email = userInfo.Email;
			UpdateUserSettings(userInfo);
			userRepository.Update(entity);
			userRepository.Commit();
		}

		public string Create(NameValueCollection queryString, string serviceName)
		{
			var user = authService.UserInfo(queryString, serviceName);
			var isExists = userRepository.FindBy(x => x.SocialId == user.SocialNetworkUserId) != null;

			if (!isExists)
			{
				var entity = user.ToEntity();
				entity.UserSettings = new EntityUserSettings
				{
					CreatedAt = DateTime.Now,
					PreferedTime = TimeSpan.Zero,
				};

				userRepository.Attach(entity);
				userRepository.Commit();
			}

			return user.SocialNetworkUserId;
		}

		private void UpdateUserSettings(UserInfo userInfo)
		{
			if (userInfo.UserSettings != null)
			{
				userSettingsRepository.Update(new EntityUserSettings
				{
					Id = userInfo.Id,
					User = userInfo.ToEntity(),
					PreferedTime = userInfo.UserSettings?.PreferedTime ?? TimeSpan.Zero
				});
			}
			else
			{
				userSettingsRepository.Attach(new EntityUserSettings
				{
					Id = userInfo.Id,
					User = userInfo.ToEntity()
				});
			}

			userSettingsRepository.Commit();
		}
	}
}
