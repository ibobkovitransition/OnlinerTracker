using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using IDependencyResolver = Microsoft.AspNet.SignalR.IDependencyResolver;

namespace OnlinerTracker.Web.Infrastructure.SignalR
{
	public class SignalrDependencyResolver : IDependencyResolver
	{
		private readonly DefaultDependencyResolver defaultDependencyResolver;

		public SignalrDependencyResolver(DefaultDependencyResolver defaultDependencyResolver)
		{
			this.defaultDependencyResolver = defaultDependencyResolver;
		}

		public void Dispose()
		{
			defaultDependencyResolver.Dispose();
		}

		public object GetService(Type serviceType)
		{
			object result;

			if (TryToGetService(serviceType, out result))
			{
				return result;
			}

			result = defaultDependencyResolver.GetService(serviceType);

			return result;
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			var results = DependencyResolver.Current.GetServices(serviceType);

			return results ?? defaultDependencyResolver.GetServices(serviceType);
		}

		public void Register(Type serviceType, Func<object> activator)
		{
		}

		public void Register(Type serviceType, IEnumerable<Func<object>> activators)
		{
		}

		private bool TryToGetService(Type serviceType, out object result)
		{
			try
			{
				var temp = DependencyResolver.Current.GetService(serviceType);
				result = temp;

				return temp != null;
			}
			catch (Exception)
			{
				result = null;
				return false;
			}
		}
	}
}