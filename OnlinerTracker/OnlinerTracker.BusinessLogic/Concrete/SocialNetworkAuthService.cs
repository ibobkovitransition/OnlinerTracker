using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth2;
using OnlinerTracker.BusinessLogic.Abstract;
using System.Collections.Specialized;
// TODO: вынести в отдельную view model
using OAuth2.Models;

namespace OnlinerTracker.BusinessLogic.Concrete
{
	public class SocialNetworkAuthService : ISocialNetworkAuthService
	{
		private readonly AuthorizationRoot _authRoot;

		public SocialNetworkAuthService(AuthorizationRoot authRoot)
		{
			_authRoot = authRoot;
		}

		public string GetRequestToken(string serviceName)
		{
			var client = _authRoot.Clients.FirstOrDefault(x => x.Name == serviceName);

			if (client == null)
				throw new ArgumentException("There is no {0} in .config", serviceName);

			return client.GetLoginLinkUri();
		}
		public UserInfo GetUserInfo(NameValueCollection queryString, string serviceName)
		{
			var client = _authRoot.Clients.FirstOrDefault(x => x.Name == serviceName);
			return client.GetUserInfo(queryString);
		}

	}
}
