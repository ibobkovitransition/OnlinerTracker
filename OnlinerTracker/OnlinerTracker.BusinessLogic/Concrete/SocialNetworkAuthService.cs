using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth2;
using OnlinerTracker.BusinessLogic.Abstract;

namespace OnlinerTracker.BusinessLogic.Concrete
{
	public class SocialNetworkAuthService : ISocialNetworkAuthService
	{
		private readonly AuthorizationRoot _authRoot;

		public SocialNetworkAuthService(AuthorizationRoot authRoot)
		{
			_authRoot = authRoot;
		}

		public string GetAuthUrl(string serviceName)
		{
			var clients = _authRoot.Clients;

			throw new NotImplementedException();
		}
	}
}
