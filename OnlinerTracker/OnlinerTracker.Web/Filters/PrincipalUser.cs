using System.Security.Principal;

namespace OnlinerTracker.Web.Filters
{
	public class PrincipalUser : IPrincipal
	{

		public int UserId { get; private set; }

		public PrincipalUser(int userId)
		{
			UserId = userId;
		}

		// TODO: ДОПИЛИТЬ В HOTFIX'E ЕСЛИ ЭТО БУДЕТ НУЖНО
		public bool IsInRole(string role) => true;

		// TODO: ДОПИЛИТЬ В HOTFIX'E ЕСЛИ ЭТО БУДЕТ НУЖНО
		public IIdentity Identity => null; 
	}
}