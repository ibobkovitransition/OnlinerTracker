using System.ComponentModel;
using System.Xml.Serialization;

namespace OnlinerTracker.BusinessLogic.Models
{
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class DailyExRates
	{
		[XmlElementAttribute("Currency")]
		public Currency[] Currency { get; set; }

		// TODO: допилить потом 
		// дата в формате dd.mm.yyyy
		[XmlAttributeAttribute()]
		public string Date { get; set; }
	}
}