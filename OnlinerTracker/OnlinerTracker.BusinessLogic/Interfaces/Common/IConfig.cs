namespace OnlinerTracker.BusinessLogic.Interfaces.Common
{
	public interface IConfig
	{
		string Email { get; }

		string EmailPassword { get; }

		string EmailHeader { get; }

		string EmailSubject { get; }

		string SmptHost { get; }

		int SmtpPort { get; }

		bool SmtpEnableSsl { get; }

		int EmailDeliveryIntervalInMinutes { get; }

		int PriceTrackingIntervalInMinutes { get; }

		string SignalrUri { get; }

		string NetMqRouterConnectionString { get; }

		string NetMqPublisherConnectionString { get; }

		string UserCookieName { get; }

		string UserConnectionCookieName { get; }
	}
}