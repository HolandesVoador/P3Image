using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace P3Image.Ioc
{
    public class NinjectDependencyResolver:  NinjectDependencyScope, IDependencyResolver
    {
       private readonly IKernel _kernel;

       public NinjectDependencyResolver(IKernel kernel)
			: base(kernel)
		{
			this._kernel = kernel;
		}

		public IDependencyScope BeginScope()
		{
			return new NinjectDependencyScope(_kernel);
		}
    }

	public class NinjectDependencyScope : IDependencyScope
	{
		private IResolutionRoot _resolver;

		internal NinjectDependencyScope(IResolutionRoot resolver)
		{
			Contract.Assert(resolver != null);

			this._resolver = resolver;
		}

		public void Dispose()
		{
			_resolver = null;
		}

		public object GetService(Type serviceType)
		{
			if (_resolver == null)
				throw new ObjectDisposedException("this", "This scope has already been disposed");

			return _resolver.TryGet(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			if (_resolver == null)
				throw new ObjectDisposedException("this", "This scope has already been disposed");

			return _resolver.GetAll(serviceType);
		}
	}
}