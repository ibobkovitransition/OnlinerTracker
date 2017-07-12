using System.Configuration;
using OnlinerTracker.BusinessLogic.Interfaces.Common;

namespace OnlinerTracker.BusinessLogic.Implementations.Common
{
	public class DeliveryConfig : IDeliveryConfig
	{
		public string Email => ConfigurationManager.AppSettings["Email"];

		public string Password => ConfigurationManager.AppSettings["Password"];

		public string Header => ConfigurationManager.AppSettings["Header"];

		public string Subject => ConfigurationManager.AppSettings["Subject"];

		public string SmptHost => ConfigurationManager.AppSettings["SmptHost"];

		public int SmtpPort => int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);

		public bool SmtpSsl => bool.Parse(ConfigurationManager.AppSettings["SmtpSsl"]);

		public int DeliveryInterval => int.Parse(ConfigurationManager.AppSettings["DeliveryInterval"]);

		public int PriceTrackingInterval => int.Parse(ConfigurationManager.AppSettings["PriceTrackingInterval"]);
		public int RequestDelay => int.Parse(ConfigurationManager.AppSettings["RequestDelay"]);
	}
}