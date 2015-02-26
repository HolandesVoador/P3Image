using Microsoft.Practices.ServiceLocation;
using P3Image.Dominio.Interfaces.Infra;

namespace P3Image.Repositorio.Configuracao
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private ContextoBanco _contexto;

        public void Iniciar()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorioHttp>()
                              as GerenciadorRepositorio;

            if (gerenciador != null) _contexto = gerenciador.Contexto;
        }

        public void Persistir()
        {
            _contexto.SaveChanges();
        }
    }
}
