namespace OnlinerTracker.BusinessLogic.Interfaces.Common
{
	public interface IHashService
	{
		string Encrypt(string content);

		string Decrypt(string content);
	}
}
