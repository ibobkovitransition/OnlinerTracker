using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class PriceHistory : BaseEntity
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }

		public bool Notified { get; set; }
	}
}