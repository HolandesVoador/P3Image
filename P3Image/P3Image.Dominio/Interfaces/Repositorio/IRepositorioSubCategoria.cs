using System.Collections.Generic;

namespace P3Image.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioSubCategoria : IRepositorioBase<SubCategoria>
    {
        IList<SubCategoria> RecuperarTodasSubCategorias();
        IList<SubCategoria> RecuperarTodasCategoriasSubCategorias();
    }
}
