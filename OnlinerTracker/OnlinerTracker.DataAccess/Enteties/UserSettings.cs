using System;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class UserSettings : BaseEntity
	{
		public TimeSpan PreferedTime { get; set; }

		public bool TrackByIncrease { get; set; }

		public bool TrackByDecrease { get; set; }
	}
}
