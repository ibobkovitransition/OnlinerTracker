using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string FullName { get; set; }
		public string Description { get; set; }
		public string HtmlUrl { get; set; }
		public decimal MinPrice { get; set; }
		public decimal MaxPrice { get; set; }
		public string IconImageUrl { get; set; }
		public string HeaderImageUrl { get; set; }
		public string ReviewUrl { get; set; }
	}
}
