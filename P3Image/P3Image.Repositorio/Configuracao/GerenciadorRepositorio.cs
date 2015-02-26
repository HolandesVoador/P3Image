using System.Web;
using P3Image.Dominio.Interfaces.Infra;

namespace P3Image.Repositorio.Configuracao
{
    public class GerenciadorRepositorio : IGerenciadorDeRepositorioHttp
    {
        public const string ContextoHttp = "ContextoHttp";

        public ContextoBanco Contexto
        {
            get
            {
                if (HttpContext.Current.Items[ContextoHttp] == null)
                {
                    HttpContext.Current.Items[ContextoHttp] = new ContextoBanco();
                }
                return HttpContext.Current.Items[ContextoHttp] as ContextoBanco;
            }
        }

        public void Finalizar()
        {
            if (HttpContext.Current.Items[ContextoHttp] != null)
            {
                ((ContextoBanco) HttpContext.Current.Items[ContextoHttp]).Dispose();
            }
        }
    }
}