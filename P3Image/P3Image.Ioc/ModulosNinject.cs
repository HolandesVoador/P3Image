using Ninject.Modules;
using P3Image.Aplicacao;
using P3Image.Dominio.Interfaces.Infra;
using P3Image.Dominio.Interfaces.Repositorio;
using P3Image.Repositorio;
using P3Image.Repositorio.Configuracao;

namespace P3Image.Ioc
{
    public class ModulosNinjectAplicacao : NinjectModule
    {
        public override void Load()
        {
            Bind<IServicoAplicacaoCategoria>().To<ServicoAplicacaoCategoria>();
            Bind<IServicoAplicacaoSubCategoria>().To<ServicoAplicacaoSubCategoria>();
        }
    }

    public class ModulosNinjectRepositorio : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositorioCategoria>().To<RepositorioCategoria>();
            Bind<IRepositorioSubCategoria>().To<RepositorioSubCategoria>();
            Bind<IRepositorioCampos>().To<RepositorioCampos>();
        }
    }

    public class ModulosNinjectInfraEstrutura : NinjectModule
    {
        public override void Load()
        {
            Bind<IGerenciadorDeRepositorioHttp>().To<GerenciadorRepositorio>();
            Bind<IUnidadeDeTrabalho>().To<UnidadeDeTrabalho>();
        }
    }

}
