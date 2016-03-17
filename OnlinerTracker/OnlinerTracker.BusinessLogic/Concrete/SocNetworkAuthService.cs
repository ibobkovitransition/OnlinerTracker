using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth2;
using OnlinerTracker.BusinessLogic.Abstract;
using System.Collections.Specialized;
using OnlinerTracker.BusinessLogic.Models;

// TODO: вынести в отдельную view model


namespace OnlinerTracker.BusinessLogic.Concrete
{
	public class SocNetworkAuthService : ISocNetworkAuthService
	{
		private readonly AuthorizationRoot authRoot;

		public SocNetworkAuthService(AuthorizationRoot authRoot)
		{
			this.authRoot = authRoot;
		}

		public string GetRequestToken(string serviceName)
		{
			var client = authRoot.Clients.FirstOrDefault(x => x.Name == serviceName);

			if (client == null)
				throw new ArgumentException("There is no {0} in .config", serviceName);

			return client.GetLoginLinkUri();
		}

		public UserInfo GetUserInfo(NameValueCollection queryString, string serviceName)
		{
			var client = authRoot.Clients.FirstOrDefault(x => x.Name == serviceName);

			if (client == null)
				throw new ArgumentException("Check your app configuration for {0}", serviceName);

			var result = client.GetUserInfo(queryString);

			return new UserInfo
			{
				FirstName = result.FirstName,
				ProviderName = result.ProviderName,
				UserId = result.Id
			};

		}

	}
}
