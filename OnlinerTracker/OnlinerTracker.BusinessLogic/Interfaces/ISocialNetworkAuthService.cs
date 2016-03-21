using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface ISocialNetworkAuthService
	{
		string AuthUrl(string serviceName);

		UserInfo UserInfo(NameValueCollection queryString, string serviceName);
	}
}
