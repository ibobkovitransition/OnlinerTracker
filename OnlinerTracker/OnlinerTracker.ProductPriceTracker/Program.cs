using Ninject;
using OnlinerTracker.BusinessLogic.Implementations.Common;
using OnlinerTracker.BusinessLogic.Implementations.ModelWrappers;
using OnlinerTracker.BusinessLogic.Implementations.Tracking;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Implementations.Ef;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.ProductPriceTracker
{
	public class Program
	{
		static void RegisterBindings(IKernel kernel)
		{
			kernel.Bind<Context>().ToSelf().InSingletonScope().WithConstructorArgument("connectionName", "EntityFrameworkDbContext");

			kernel.Bind<IRepository<User>>().To<Repository<User>>();
			kernel.Bind<IRepository<Product>>().To<Repository<Product>>();
			kernel.Bind<IRepository<ProductTracking>>().To<Repository<ProductTracking>>();
			kernel.Bind<IRepository<UserSettings>>().To<Repository<UserSettings>>();
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

			kernel.Bind<IProductTrackingService>().To<ProductTrackingService>();
			kernel.Bind<IScheduleService>().To<PriceScheduleService>();

			kernel.Bind<IProductService>().To<ProductService>();
			kernel.Bind<IPriceTrackingService>().To<ProductPriceTrackingService>();
			kernel.Bind<IRepository<PriceHistory>>().To<Repository<PriceHistory>>();
			kernel.Bind<IProductSearchService>().To<OnlinerProductSearchService>();
			kernel.Bind<IPriceHistoryService>().To<ProductPriceHistoryService>();
		}

		static void Main(string[] args)
		{
			// TODO: OT.BusinessLogic.Models:
			// 1 Добавить базовую сущность для моделей
			// 2 научитить все парсеры нормально работать
			
			IKernel kernel = new StandardKernel();
			RegisterBindings(kernel);
			kernel.Get<IScheduleService>().Execute();
		}
	}
}
