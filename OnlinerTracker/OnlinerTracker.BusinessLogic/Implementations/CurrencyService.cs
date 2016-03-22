using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class CurrencyService : ICurrencyService
	{
		public IEnumerable<Currency> CurrencyList()
		{
			var request = (HttpWebRequest)WebRequest.Create($"http://www.nbrb.by/Services/XmlExRates.aspx?ondate={DateTime.Now.ToString("MM-dd-yyyy")}");
			request.Method = "GET";
			request.Accept = "text/xml";
			var response = request.GetResponse();
			var stream = response.GetResponseStream();

			if (stream == null)
			{
				throw new ArgumentException("response stream is null");
			}

			var reader = new StreamReader(stream);
			var serializer = new XmlSerializer(typeof(DailyExRates));
			var result = (DailyExRates)serializer.Deserialize(reader);
			reader.Close();

			return result.Currency;
		}
	}
}