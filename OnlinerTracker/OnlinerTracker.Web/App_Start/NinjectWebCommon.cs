using OAuth2;
using OnlinerTracker.BusinessLogic.Implementations;
using OnlinerTracker.BusinessLogic.Interfaces;
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
			// self BL & DA
			kernel.Bind<AuthorizationRoot>().ToSelf();
			kernel.Bind<Context>().ToSelf().InSingletonScope().WithConstructorArgument("connectionName", "EntityFrameworkDbContext");

			// direct BL
			kernel.Bind<ISocNetworkAuthService>().To<SocNetworkAuthService>();
			kernel.Bind<ICookieService>().To<CookieService>();
			kernel.Bind<IHashService>().To<Base64HashService>();
			kernel.Bind<IProductSearchService>().To<OnlinerProductSearchService>();

			// indirectly DAL
			kernel.Bind<IRepository<User>>().To<Repository<User>>();
			kernel.Bind<IRepository<Product>>().To<Repository<Product>>();
			kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

			// indirectly BLL
			kernel.Bind<IUserService>().To<UserService>();
			kernel.Bind<IProductService>().To<ProductService>();
		}
	}
}
