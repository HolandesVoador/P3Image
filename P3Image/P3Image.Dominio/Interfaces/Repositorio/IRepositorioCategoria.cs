using System.Collections.Generic;

namespace P3Image.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioCategoria : IRepositorioBase<Categoria>
    {
        IList<Categoria> RecuperarTodasCategorias();
        IList<Categoria> RetornarCategoriasDisponiveis();

    }
}
