using FluentScheduler;

namespace OnlinerTracker.BusinessLogic.Interfaces.Notification
{
	public interface INotifyScheduleService : IJob
	{
		void Execute();
	}
}