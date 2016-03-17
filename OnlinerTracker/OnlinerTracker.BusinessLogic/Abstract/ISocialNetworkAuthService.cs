using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
// TODO: вынести в отдельную view model
using OAuth2.Models;

namespace OnlinerTracker.BusinessLogic.Abstract
{
	public interface ISocialNetworkAuthService
	{
		string GetAuthUrl(string serviceName);
		UserInfo GetProtectedResources(NameValueCollection queryString, string serviceName);
	}
}
