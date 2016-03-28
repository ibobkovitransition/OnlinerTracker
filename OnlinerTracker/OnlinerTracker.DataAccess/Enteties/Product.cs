using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class Product : BaseEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public override int Id { get; set; }

		public string FullName { get; set; }

		public string Description { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }

		public string IconImageUrl{ get; set; }

		public string HeaderImageUrl { get; set; }

		public ICollection<ProductTracking> ProductTracking { get; set; }

		public ICollection<PriceHistory> PriceHistory { get; set; }

		public Product()
		{
			ProductTracking = new List<ProductTracking>();
			PriceHistory = new List<PriceHistory>();
		}
	}
}
