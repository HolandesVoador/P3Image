using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace P3Image.Ioc
{
    public class NinjectScope : IDependencyScope
    {
        private IResolutionRoot _kernel;

        public NinjectScope(IResolutionRoot kernel)
        {
            _kernel = kernel;
        }

        protected NinjectScope()
        {
        }

        public void Dispose()
        {
            var disposable = (IDisposable) _kernel;
            if (disposable != null) disposable.Dispose();
            _kernel = null;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}