namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface IHashService
	{
		string Encrypt(string content);

		string Decript(string content);
	}
}
