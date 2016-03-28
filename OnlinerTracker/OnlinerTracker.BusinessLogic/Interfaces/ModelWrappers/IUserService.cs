using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Models.User;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface IUserService
	{
		/// <summary>
		/// Add user into db
		/// </summary>
		/// <param name="queryString">Request.QueryString</param>
		/// <param name="serviceName">Facebook, Twitter, Vk</param>
		/// <returns>Social network userid</returns>
		string AddUser(NameValueCollection queryString, string serviceName);

		UserInfo Get(int userId);

		UserInfo GetBySocialId(string socialId);

		void Update(int userId, UserInfo userInfo);
	}
}
