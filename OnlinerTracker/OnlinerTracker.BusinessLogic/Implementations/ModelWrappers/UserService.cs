using System;
using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Extensions;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.User;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Interfaces;
using UserSettings = OnlinerTracker.DataAccess.Enteties.UserSettings;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> userRepository;
		private readonly ISocialNetworkAuthService authService;

		public UserService(ISocialNetworkAuthService authService, IRepository<User> userRepository)
		{
			this.authService = authService;
			this.userRepository = userRepository;
		}

		public UserInfo Get(int userId)
		{
			var user = userRepository.FindBy(x => x.Id == userId);
			return user.ToModel();
		}

		public UserInfo GetBySocialId(string socialId)
		{
			var user = userRepository.FindBy(x => x.SocialId == socialId);
			return user?.ToModel();
		}

		public void Update(int userId, UserInfo userInfo)
		{
			var entity = userRepository.FindBy(x => x.Id == userId, x => x.UserSettings);
			entity.Email = userInfo.Email;

			entity.UserSettings = entity.UserSettings ?? new UserSettings
			{
				Id = userId,
				CreatedAt = DateTime.Now
			};

			entity.UserSettings.PreferedTime = userInfo.UserSettings?.PreferedTime ?? TimeSpan.Zero;
			userRepository.Update(entity);
			userRepository.Commit();
		}

		public string AddUser(NameValueCollection queryString, string serviceName)
		{
			var user = authService.UserInfo(queryString, serviceName);
			var isExists = userRepository.FindBy(x => x.SocialId == user.SocialNetworkUserId) != null;

			if (!isExists)
			{
				var entity = user.ToEntity();
				entity.UserSettings = new UserSettings
				{
					CreatedAt = DateTime.Now,
					PreferedTime = TimeSpan.Zero,
				};

				userRepository.Attach(entity);
				userRepository.Commit();
			}

			return user.SocialNetworkUserId;
		}
	}
}
