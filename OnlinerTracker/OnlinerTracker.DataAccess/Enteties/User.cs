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

		public ICollection<ProductTracking> ProductTracking { get; set; }

		public ICollection<NotifyHistory> NotifyHistory { get; set; }

		public User()
		{
			ProductTracking = new List<ProductTracking>();
			NotifyHistory = new List<NotifyHistory>();
		}
	}
}
