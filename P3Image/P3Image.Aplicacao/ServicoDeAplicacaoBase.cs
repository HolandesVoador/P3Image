using Microsoft.Practices.ServiceLocation;
using P3Image.Dominio.Interfaces.Infra;

namespace P3Image.Aplicacao
{
    public class ServicoDeAplicacaoBase : IServicoDeAplicacaoBase
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;

        public ServicoDeAplicacaoBase()
        {
            _unidadeDeTrabalho = ServiceLocator.Current.GetInstance<IUnidadeDeTrabalho>();
        }

        public void IniciarTransacao()
        {
            _unidadeDeTrabalho.Iniciar();
        }

        public void PersistirTransacao()
        {
            _unidadeDeTrabalho.Persistir();
        }
    }
}
