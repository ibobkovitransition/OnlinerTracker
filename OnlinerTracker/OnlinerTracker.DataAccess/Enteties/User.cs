using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class User : BaseEntity
	{
		public string FirstName { get; set; }
		public string UserId { get; set; }
		public string PhotoUri { get; set; }
		public string Email { get; set; }
	}
}
