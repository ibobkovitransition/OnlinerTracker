using OnlinerTracker.BusinessLogic.Interfaces.Common;
using System.Configuration;

namespace OnlinerTracker.BusinessLogic.Implementations.Common
{
	public class Config : IConfig
	{
		public string SignalrUri => ConfigurationManager.AppSettings["SignalrUri"];

		public string NetMqRouter => ConfigurationManager.AppSettings["NetMqRouter"];

		public string NetMqPublisher => ConfigurationManager.AppSettings["NetMqPublisher"];

		public string UserCookie => ConfigurationManager.AppSettings["UserCookie"];

		public string UserConnectionCookie => ConfigurationManager.AppSettings["UserConnectionCookie"];

		public bool UseNetMq => bool.Parse(ConfigurationManager.AppSettings["UseNetMq"]);
	}
}