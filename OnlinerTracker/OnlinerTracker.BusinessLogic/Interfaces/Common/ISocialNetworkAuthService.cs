using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Models.User;

namespace OnlinerTracker.BusinessLogic.Interfaces.Common
{
	public interface ISocialNetworkAuthService
	{
		string AuthUrl(string serviceName);

		UserInfo UserInfo(NameValueCollection queryString, string serviceName);
	}
}
