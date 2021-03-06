﻿using System;
using FluentScheduler;
using Ninject;
using OnlinerTracker.BusinessLogic.Implementations.Common;
using OnlinerTracker.BusinessLogic.Implementations.ModelWrappers;
using OnlinerTracker.BusinessLogic.Implementations.Notification;
using OnlinerTracker.BusinessLogic.Implementations.Tracking;
using OnlinerTracker.BusinessLogic.Interfaces.Common;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Interfaces.Tracking;
using OnlinerTracker.DataAccess.Enteties;
using OnlinerTracker.DataAccess.Implementations.Ef;
using OnlinerTracker.DataAccess.Interfaces;

namespace OnlinerTracker.ProductPriceTracker
{
	public class Program
	{
		private static void RegisterBindings(IKernel kernel)
		{
			kernel.Bind<Context>().ToSelf().WithConstructorArgument("connectionName", "EntityFrameworkDbContext");

			kernel.Bind<IRepository<User>>().To<Repository<User>>();
			kernel.Bind<IRepository<Product>>().To<Repository<Product>>();
			kernel.Bind<IRepository<ProductTracking>>().To<Repository<ProductTracking>>();
			kernel.Bind<IRepository<UserSettings>>().To<Repository<UserSettings>>();
			kernel.Bind<IRepository<NotifyHistory>>().To<Repository<NotifyHistory>>();

			kernel.Bind<IProductTrackingService>().To<ProductTrackingService>();
			kernel.Bind<IPriceScheduleService>().To<PriceScheduleService>();

			kernel.Bind<IProductService>().To<ProductService>();
			kernel.Bind<IPriceTrackingService>().To<PriceTrackingService>();
			kernel.Bind<IRepository<PriceHistory>>().To<Repository<PriceHistory>>();
			kernel.Bind<IProductSearchService>().To<OnlinerProductSearchService>();
			kernel.Bind<IPriceHistoryService>().To<PriceHistoryService>();

			kernel.Bind<INotifyScheduleService>().To<NotifyScheduleService>();
			kernel.Bind<INotifyService>().To<NotifyService>();
			kernel.Bind<IEmailNotifyService>().To<GmailNotifyService>();
			kernel.Bind<INotifyMessageCreator>().To<NotifyMessageCreator>();
			kernel.Bind<INotifyResultCreator>().To<NotifyResultCreator>();
			kernel.Bind<INotifyQueueManager>().To<NotifyQueueManager>();
			kernel.Bind<INotifyHistoryService>().To<NotifyHistoryService>();
		}

		private static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel();
			RegisterBindings(kernel);

			JobManager.JobFactory = new JobFactory(kernel);
			JobManager.Initialize(new ScheduleRegistry());

			Console.WriteLine("Press any key to close");
			Console.ReadKey();
		}
	}
}
