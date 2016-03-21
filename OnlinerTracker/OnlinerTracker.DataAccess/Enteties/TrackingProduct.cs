using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class TrackingProduct : BaseEntity
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public bool Enabled { get; set; }
	}
}