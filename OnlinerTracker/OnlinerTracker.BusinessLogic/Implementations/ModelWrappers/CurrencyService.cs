using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.Exchange;

namespace OnlinerTracker.BusinessLogic.Implementations.ModelWrappers
{
	public class CurrencyService : ICurrencyService
	{
		public IEnumerable<Currency> CurrencyList()
		{
			var stream = GetResponseStream();
			var result = DeserializeResponseStream(stream);

			return result.Currency;
		}

		private DailyExchangeRates DeserializeResponseStream(Stream stream)
		{
			var reader = new StreamReader(stream);
			var serializer = new XmlSerializer(typeof (DailyExchangeRates));
			var result = (DailyExchangeRates) serializer.Deserialize(reader);
			reader.Close();

			return result;
		}

		private Stream GetResponseStream()
		{
			var request =
				(HttpWebRequest)
					WebRequest.Create($"http://www.nbrb.by/Services/XmlExRates.aspx?ondate={DateTime.Now.ToString("MM-dd-yyyy")}");

			request.Method = "GET";
			request.Accept = "text/xml";
			var response = request.GetResponse();
			var stream = response.GetResponseStream();

			if (stream == null)
			{
				throw new ArgumentException("response stream is null");
			}

			return stream;
		}
	}
}