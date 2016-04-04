namespace OnlinerTracker.BusinessLogic.Interfaces.Common
{
	public interface IConfig
	{
		string SignalrUri { get; }

		string NetMqRouter { get; }

		string NetMqPublisher { get; }

		string UserCookie { get; }

		string UserConnectionCookie { get; }

		bool UseNetMq { get; }
	}
}