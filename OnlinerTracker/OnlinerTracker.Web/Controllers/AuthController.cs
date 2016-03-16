using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlinerTracker.BusinessLogic.Abstract;
using OnlinerTracker.DataAccess.Abstract;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.Web.Controllers
{
	public class AuthController : ApiController
	{
		private readonly IUnitOfWork _uow;
		private readonly ISocialNetworkAuthService _auth;
		private readonly IRepository<User> _repository; 

		public AuthController(IUnitOfWork uow, ISocialNetworkAuthService auth)
		{
			_uow = uow;
			_repository = uow.UserRepository;
			_auth = auth;
		}

		public string Get(string id)
		{
			// calls new exception
			_auth.GetAuthUrl(id);
			//_repository.Create(new User());
			return id;
		}
	}
}
