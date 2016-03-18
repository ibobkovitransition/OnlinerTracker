using System.Collections.Specialized;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface ISocNetworkAuthService
	{
		string GetRequestToken(string serviceName);

		User GetUserInfo(NameValueCollection queryString, string serviceName);
	}
}
