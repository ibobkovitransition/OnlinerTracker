using System.Collections.Generic;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class User : BaseEntity
	{
		public string FirstName { get; set; }

		public string SocialId { get; set; }

		public string Email { get; set; }

		public UserSettings UserSettings { get; set; }

		public int UserSettingsId { get; set; }

		public ICollection<ProductTracking> TrackedProducts { get; set; }

		public User()
		{
			TrackedProducts = new List<ProductTracking>();
		}
	}
}
