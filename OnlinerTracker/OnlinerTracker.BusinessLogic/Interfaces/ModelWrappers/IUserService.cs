using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Models.User;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface IUserService
	{
		string Create(NameValueCollection queryString, string serviceName);

		UserInfo Get(int userId);

		UserInfo GetBySocialId(string socialId);

		void Update(int userId, UserInfo userInfo);
	}
}
