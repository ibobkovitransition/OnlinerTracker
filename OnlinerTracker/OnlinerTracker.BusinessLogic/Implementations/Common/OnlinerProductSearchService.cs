using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Models.Onliner;

namespace OnlinerTracker.BusinessLogic.Implementations.Common
{
	public class OnlinerProductSearchService : IProductSearchService
	{
		public SearchResult Search(string productName, int page, int size)
		{
			var stream = GetResponseStream(productName, page, size);
			return ParseStream(stream); ;
		}

		private static SearchResult ParseStream(Stream stream)
		{
			var reader = new StreamReader(stream);
			var result = JsonConvert.DeserializeObject<SearchResult>(reader.ReadToEnd());
			return result;
		}

		private static Stream GetResponseStream(string productName, int page, int size)
		{
			var request =
				(HttpWebRequest)
					WebRequest.Create($"https://catalog.api.onliner.by/search/products?query={productName}&page={page}&limit={size}");
			request.Method = "GET";
			request.Accept = "application/json";
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
