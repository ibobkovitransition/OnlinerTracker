namespace OnlinerTracker.BusinessLogic.Models
{
	public class ProductTracking
	{
		public Product Product { get; set; }

		public decimal NewMaxPrice { get; set; }

		public decimal NewMinPrice { get; set; }

		public UserInfo UserInfo { get; set; }

		public bool Increase { get; set; }

		public bool Decrease { get; set; }
	}
}