using System.ComponentModel;
using System.Xml.Serialization;

namespace OnlinerTracker.BusinessLogic.Models
{
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true)]
	public class Currency
	{
		public int NumCode { get; set; }

		public string CharCode { get; set; }

		public int Scale { get; set; }

		public string Name { get; set; }

		public decimal Rate { get; set; }

		[System.Xml.Serialization.XmlAttributeAttribute()]
		public int Id { get; set; }
	}
}