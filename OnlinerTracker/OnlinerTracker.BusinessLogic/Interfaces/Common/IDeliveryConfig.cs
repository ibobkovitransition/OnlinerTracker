namespace OnlinerTracker.BusinessLogic.Interfaces.Common
{
	public interface IDeliveryConfig
	{
		string Email { get; }

		string Password { get; }

		string Header { get; }

		string Subject { get; }

		string SmptHost { get; }

		int SmtpPort { get; }

		bool SmtpSsl { get; }

		/// <summary>
		/// interval in minutes
		/// </summary>
		int DeliveryInterval { get; }

		/// <summary>
		/// interval in minutes
		/// </summary>
		int PriceTrackingInterval { get; }
	}
}