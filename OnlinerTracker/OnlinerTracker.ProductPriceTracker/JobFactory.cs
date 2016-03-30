using FluentScheduler;
using Ninject;

namespace OnlinerTracker.ProductPriceTracker
{
	public class JobFactory : IJobFactory
	{
		private readonly IKernel kernel;

		public JobFactory(IKernel kernel)
		{
			this.kernel = kernel;
		}

		public IJob GetJobInstance<T>() where T : IJob
		{
			return kernel.Get<T>();
		}
	}
}