namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IHashService
	{
		string Encrypt(string content);

		string Decrypt(string content);
	}
}
