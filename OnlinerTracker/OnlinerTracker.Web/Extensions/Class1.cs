using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace OnlinerTracker.Web.Extensions
{
	public static class HttpRequestMessageExtensions
	{
		/// <summary>
		/// Returns a dictionary of QueryStrings that's easier to work with 
		/// than GetQueryNameValuePairs KevValuePairs collection.
		/// 
		/// If you need to pull a few single values use GetQueryString instead.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static Dictionary<string, string> GetQueryStrings(
			this HttpRequestMessage request)
		{
			return request.GetQueryNameValuePairs()
						  .ToDictionary(kv => kv.Key, kv => kv.Value,
							   StringComparer.OrdinalIgnoreCase);
		}
	}
}