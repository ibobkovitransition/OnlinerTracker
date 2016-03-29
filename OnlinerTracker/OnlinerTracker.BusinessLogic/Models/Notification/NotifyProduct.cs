using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Models.Notification
{
	public class NotifyProduct
	{
		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }

		public Product Product { get; set; }
	}
}