using System.ComponentModel;
using System.Xml.Serialization;

namespace OnlinerTracker.BusinessLogic.Models.Exchange
{
	[XmlRoot("DailyExRates")]
	public class DailyExchangeRates
	{
		[XmlElement("Currency")]
		public Currency[] Currency { get; set; }

		[XmlAttribute]
		public string Date { get; set; }
	}
}