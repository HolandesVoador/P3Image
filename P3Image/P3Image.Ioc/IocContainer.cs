using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;


namespace P3Image.Ioc
{
    public class IocContainer
    {
        public IKernel Kernel { get; private set; }

        public IocContainer()
        {
            Kernel = new StandardKernel(
                new ModulosNinjectAplicacao(),
                new ModulosNinjectInfraEstrutura(),
                new ModulosNinjectRepositorio());

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }
    }
}
