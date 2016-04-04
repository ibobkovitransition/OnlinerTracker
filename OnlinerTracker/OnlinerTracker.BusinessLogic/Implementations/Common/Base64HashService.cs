using System;
using System.Text;
using OAuth2.Infrastructure;
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
			if (string.IsNullOrEmpty(content))
			{
				return null;
			}

			// TODO: НЕ ПОДДЕРЖИВАЕТ ЛОГИН В ВК ПО EMAIL'Y 1141
			var bytes = Convert.FromBase64String(content);
			return Encoding.UTF8.GetString(bytes);
		}
	}
}
