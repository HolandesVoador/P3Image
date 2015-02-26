using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using P3Image.Dominio;
using P3Image.Dominio.Interfaces.Repositorio;

namespace P3Image.Repositorio
{
    public class RepositorioSubCategoria : RepositorioBase<SubCategoria>, IRepositorioSubCategoria
    {
        public override SubCategoria RecuperarPorId(int id)
        {
            return Entidades.SubCategorias.Include("Campos").SingleOrDefault(r => r.Id == id);
        }

        public IList<SubCategoria> RecuperarTodasSubCategorias()
        {
            return Entidades.SubCategorias.Include("Campos").ToList();
        }

        public IList<SubCategoria> RecuperarTodasCategoriasSubCategorias()
        {
            return Entidades.SubCategorias
                
                .Include("Categoria")
                .Include("Campos").ToList();
        }
    }
}
