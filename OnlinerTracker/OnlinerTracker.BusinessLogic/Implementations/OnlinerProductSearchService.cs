using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class OnlinerProductSearchService : IProductSearchService
	{
		public SearchResult Search(string productName, int page, int size)
		{
			var request = (HttpWebRequest)WebRequest.Create($"https://catalog.api.onliner.by/search/products?query={productName}&page={page}&limit={size}");
			request.Method = "GET";
			request.Accept = "application/json";
			var response = request.GetResponse();
			var stream = response.GetResponseStream();

			if (stream == null)
			{
				throw new ArgumentException("response stream is null");
			}

			var reader = new StreamReader(stream);

			return JsonConvert.DeserializeObject<SearchResult>(reader.ReadToEnd());
		}
	}
}
