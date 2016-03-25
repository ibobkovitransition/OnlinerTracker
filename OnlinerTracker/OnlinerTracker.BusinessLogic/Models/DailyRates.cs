using System.ComponentModel;
using System.Xml.Serialization;

namespace OnlinerTracker.BusinessLogic.Models
{
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class DailyExRates
	{
		[XmlElement("Currency")]
		public Currency[] Currency { get; set; }

		// TODO: допилить потом 
		// дата в формате dd.mm.yyyy
		[XmlAttribute]
		public string Date { get; set; }
	}
}