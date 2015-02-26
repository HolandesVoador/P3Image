using System.Data.Entity;
using P3Image.Dominio;
using P3Image.Dominio.Interfaces.Repositorio;
using P3Image.Repositorio.Configuracao;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using P3Image.Dominio.Interfaces.Infra;

namespace P3Image.Repositorio
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : Identificador
    {
        protected readonly ContextoBanco Entidades;

        public RepositorioBase()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IGerenciadorDeRepositorioHttp>() as GerenciadorRepositorio;
            if (gerenciador != null) Entidades = gerenciador.Contexto;
        }

        public virtual TEntidade RecuperarPorId(int id)
        {
            return Entidades.Set<TEntidade>().SingleOrDefault(r => r.Id == id);
        }

        public void Inserir(TEntidade obj)
        {
            Entidades.Set<TEntidade>().Add(obj);
        }

        public void Alterar(TEntidade obj)
        {
            Entidades.Entry(obj).State = EntityState.Modified;
        }

        public void Remover(TEntidade obj)
        {
            Entidades.Set<TEntidade>().Remove(obj);
        }

        public void Remover(int id)
        {
            TEntidade obj = RecuperarPorId(id);
            Remover(obj);
        }
    }
}
