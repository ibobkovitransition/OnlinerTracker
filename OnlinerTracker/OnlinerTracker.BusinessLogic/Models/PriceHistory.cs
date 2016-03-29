using OnlinerTracker.BusinessLogic.Models.Basis;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class PriceHistory : BaseModel
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }

		public bool Notifited { get; set; }
	}
}