using System.Collections.Generic;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class User : BaseEntity
	{
		public string FirstName { get; set; }

		public string SocialId { get; set; }

		public string PhotoUri { get; set; }

		public string Email { get; set; }

		//public UserSettings Settings { get; set; }

		//public int SettingsId { get; set; }

		public ICollection<TrackingProduct> TrackedProducts { get; set; }

		public User()
		{
			TrackedProducts = new List<TrackingProduct>();
		}
	}
}
