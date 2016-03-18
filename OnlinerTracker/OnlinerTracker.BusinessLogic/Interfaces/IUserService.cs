using System.Collections.Specialized;

namespace OnlinerTracker.BusinessLogic.Interfaces
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
	}
}
