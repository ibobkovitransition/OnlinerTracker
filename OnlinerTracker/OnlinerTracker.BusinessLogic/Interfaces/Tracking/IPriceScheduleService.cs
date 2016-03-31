using FluentScheduler;

namespace OnlinerTracker.BusinessLogic.Interfaces.Tracking
{
	public interface IPriceScheduleService : IJob
	{
		void Execute();
	}
}