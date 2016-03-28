using OAuth2;
using OnlinerTracker.BusinessLogic.Implementations.Common;
using OnlinerTracker.BusinessLogic.Implementations.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Implementations.Ef;
using OnlinerTracker.DataAccess.Interfaces;
using OnlinerTracker.Web.Implementations;
using OnlinerTracker.Web.Interaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlinerTracker.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlinerTracker.Web.App_Start.NinjectWebCommon), "Stop")]

namespace OnlinerTracker.Web.App_Start
{
	using System;
	using System.Web;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using Ninject;
	using Ninject.Web.Common;

	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<AuthorizationRoot>().ToSelf();
			kernel.Bind<Context>().ToSelf().InSingletonScope().WithConstructorArgument("connectionName", "EntityFrameworkDbContext");

			kernel.Bind<ISocialNetworkAuthService>().To<SocialNetworkAuthService>();
			kernel.Bind<ICookieService>().To<CookieService>();
			kernel.Bind<IHashService>().To<Base64HashService>();
			kernel.Bind<IProductSearchService>().To<OnlinerProductSearchService>();
			kernel.Bind<ICurrencyService>().To<CurrencyService>();

			kernel.Bind<IRepository<User>>().To<Repository<User>>();
			kernel.Bind<IRepository<Product>>().To<Repository<Product>>();
			kernel.Bind<IRepository<ProductTracking>>().To<Repository<ProductTracking>>();
			kernel.Bind<IRepository<UserSettings>>().To<Repository<UserSettings>>();
			kernel.Bind<IRepository<PriceHistory>>().To<Repository<PriceHistory>>();
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
			
			kernel.Bind<IUserService>().To<UserService>();
			kernel.Bind<IProductTrackingService>().To<ProductTrackingService>();
			kernel.Bind<IProductService>().To<ProductService>();
		}
	}
}
