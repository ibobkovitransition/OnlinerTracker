using System;
using FluentScheduler;
using OnlinerTracker.BusinessLogic.Interfaces;

namespace OnlinerTracker.BusinessLogic.Implementations
{
	public class PriceScheduleService : IScheduleService, IJob
	{
		private readonly IPriceTrackingService priceTrackingService;

		public PriceScheduleService(IPriceTrackingService priceTrackingService)
		{
			this.priceTrackingService = priceTrackingService;
		}

		public void Execute()
		{
			// find
			priceTrackingService.FindChangedPrices();

			// add into table
			// here
			//throw new Exception();
		}
	}
}