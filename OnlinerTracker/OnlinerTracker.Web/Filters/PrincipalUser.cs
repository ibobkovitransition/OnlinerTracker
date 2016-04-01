using System.Security.Principal;

namespace OnlinerTracker.Web.Filters
{
	public class PrincipalUser : IPrincipal
	{ 
		public int Id { get; private set; }

		public string ConnectionId { get; private set; }

		public PrincipalUser(int userId, string connectionId)
		{
			Id = userId;
			ConnectionId = connectionId;
		}

		public bool IsInRole(string role) => true;

		public IIdentity Identity => null; 
	}
}