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

		public string Name { get; set; }

		public string FullName { get; set; }

		public string Description { get; set; }

		public string HtmlUrl { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }

		public string ImageUrl { get; set; }

		public ICollection<TrackingProduct> TrackedProducts { get; set; }

		public Product()
		{
			TrackedProducts = new List<TrackingProduct>();
		}
	}
}
