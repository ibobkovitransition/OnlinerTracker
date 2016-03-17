using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class User : BaseEntity
	{
		public string FirstName { get; set; }
		public string SocNetworkId { get; set; }
	}
}
