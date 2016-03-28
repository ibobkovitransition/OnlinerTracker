using System;
using System.Text;
using OnlinerTracker.BusinessLogic.Interfaces.Common;

namespace OnlinerTracker.BusinessLogic.Implementations.Common
{
	public class Base64HashService : IHashService
	{
		public string Encrypt(string content)
		{
			var bytes = Encoding.UTF8.GetBytes(content);
			return Convert.ToBase64String(bytes);
		}

		public string Decrypt(string content)
		{
			var bytes = Convert.FromBase64String(content);
			return Encoding.UTF8.GetString(bytes);
		}
	}
}
