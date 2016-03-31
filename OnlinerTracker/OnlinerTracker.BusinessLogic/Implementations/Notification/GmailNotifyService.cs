using System.Net;
using System.Net.Mail;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class GmailNotifyService : IEmailNotifyService
	{
		private const string password = "ava4v4zsk";

		public void Send(string message, string email)
		{
			var from = new MailAddress("not4niceperson@gmail.com", "OnlinerTracker");
			var to = new MailAddress(email, "YOU, PIG");
			var smtp = ConfigSmtp(@from, password);

			using (var mailmessage = new MailMessage(from, to)
			{
				Subject = "Notification",
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
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(@from.Address, fromPassword)
			};
			return smtp;
		}
	}
}