using OnlinerTracker.BusinessLogic.Interfaces.Common;

namespace OnlinerTracker.BusinessLogic.Implementations.Common
{
	public class Config : IConfig
	{
		public string Email => "not4niceperson@gmail.com";
		public string EmailPassword => "ava4v4zsk";

		public string EmailHeader => "OnlinerTracker";

		public string EmailSubject => "OnlinerTracker";

		public string SmptHost => "smtp.gmail.com";

		public int SmtpPort => 587;

		public bool SmtpEnableSsl => true;

		public int EmailDeliveryIntervalInMinutes => 30;

		public int PriceTrackingIntervalInMinutes => 13;

		public string SignalrUri => "/echo";

		public string NetMqRouterConnectionString => "ws://localhost:91";

		public string NetMqPublisherConnectionString => "ws://localhost:92";

		public string UserCookieName => "onliner_tracker";

		public string UserConnectionCookieName => "connection_id";
	}
}