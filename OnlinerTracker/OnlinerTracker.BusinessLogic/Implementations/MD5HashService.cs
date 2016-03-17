using System.Security.Cryptography;
using System.Text;
using OnlinerTracker.BusinessLogic.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class MD5HashService : IHashService
	{
		private readonly MD5 md5 = new MD5CryptoServiceProvider();

		public string Encrypt(string content)
		{
			md5.ComputeHash(Encoding.UTF8.GetBytes(content));
			byte[] bytes = md5.Hash;

			StringBuilder sBuilder = new StringBuilder();
			foreach (byte @byte in bytes)
			{
				sBuilder.Append(@byte.ToString("x2"));
			}

			return sBuilder.ToString();
		}
	}
}
