using System;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class ProductPriceHistory
	{
		public int Id { get; set; }

		public DateTime CreatedOn { get; set; }

		public int ProductId { get; set; }

		public Product Product { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }
	}
}