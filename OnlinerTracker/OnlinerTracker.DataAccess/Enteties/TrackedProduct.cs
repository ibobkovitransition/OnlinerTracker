using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class TrackedProduct : BaseEntity
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public bool IsTracked { get; set; }
	}
}