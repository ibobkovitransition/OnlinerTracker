using OnlinerTracker.BusinessLogic.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class GoogleEmailProvider : IEmailProvider
	{
		// http://stackoverflow.com/questions/32260/sending-email-in-net-through-gmail
		public void Send(string message)
		{
			throw new System.NotImplementedException();
		}
	}
}