using Ninject;
using OnlinerTracker.BusinessLogic.Implementations;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Implementations.Ef;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.ProductPriceTracker
{
	public class Program
	{
		static void Register(IKernel kernel)
		{
			kernel.Bind<Context>().ToSelf().InSingletonScope().WithConstructorArgument("connectionName", "EntityFrameworkDbContext");

			kernel.Bind<IRepository<User>>().To<Repository<User>>();
			kernel.Bind<IRepository<Product>>().To<Repository<Product>>();
			kernel.Bind<IRepository<ProductTracking>>().To<Repository<ProductTracking>>();
			kernel.Bind<IRepository<UserSettings>>().To<Repository<UserSettings>>();
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

			kernel.Bind<IProductTrackingService>().To<ProductTrackingService>();
			kernel.Bind<IScheduleService>().To<PriceScheduleService>();

			kernel.Bind<IPriceTrackingService>().To<ProductPriceTrackingService>();
			kernel.Bind<IRepository<ProductPriceHistory>>().To<Repository<ProductPriceHistory>>();
			//kernel.Bind<IUserNotifyService>().To<UserNotificationService>();
			//kernel.Bind<INotifyMessageCreatorService>().To<NotifyMessageCreatorService>();
			//kernel.Bind<IEmailProvider>().To<GoogleEmailProvider>();
			kernel.Bind<IProductSearchService>().To<OnlinerProductSearchService>();
		}

		static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel();
			Register(kernel);
			kernel.Get<IScheduleService>().Execute();
		}
	}
}
