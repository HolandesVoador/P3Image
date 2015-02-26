
using System.Collections.Generic;
using System.Linq;
using P3Image.Dominio;
using P3Image.Dominio.Interfaces.Repositorio;

namespace P3Image.Repositorio
{
    public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorioCategoria
    {
        public IList<Categoria> RecuperarTodasCategorias()
        {
            return Entidades.Categorias.ToList();
        }

        public IList<Categoria> RetornarCategoriasDisponiveis()
        {
            var utilizadas = Entidades.SubCategorias.AsNoTracking().Select(e => e.Categoria);

            return Entidades.Categorias.AsNoTracking().Except(utilizadas).Cast<Categoria>().ToList();
        }
    }
}
