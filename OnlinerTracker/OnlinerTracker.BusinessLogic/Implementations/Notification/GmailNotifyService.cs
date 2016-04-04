using System.Net;
using System.Net.Mail;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class GmailNotifyService : IEmailNotifyService
	{
		private readonly IConfig config;

		public GmailNotifyService(IConfig config)
		{
			this.config = config;
		}

		public void Send(string message, string email)
		{
			var from = new MailAddress(config.Email, config.EmailHeader);
			var to = new MailAddress(email, config.EmailSubject);
			var smtp = ConfigSmtp(@from, config.EmailPassword);

			using (var mailmessage = new MailMessage(from, to)
			{
				Subject = config.EmailSubject,
				Body = message
			})
			{
				smtp.Send(mailmessage);
			}
		}

		private SmtpClient ConfigSmtp(MailAddress @from, string fromPassword)
		{
			var smtp = new SmtpClient
			{
				Host = config.SmptHost,
				Port = config.SmtpPort,
				EnableSsl = config.SmtpEnableSsl,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(@from.Address, fromPassword)
			};
			return smtp;
		}
	}
}