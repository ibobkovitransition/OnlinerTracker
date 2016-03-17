using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Abstract
{
	public interface ISocNetworkAuthService
	{
		string GetRequestToken(string serviceName);
		UserInfo GetUserInfo(NameValueCollection queryString, string serviceName);
	}
}
