using System.Collections.Generic;
using System.Linq;
using P3Image.Dominio;

namespace P3Image.Aplicacao
{
    public interface IServicoAplicacaoCategoria
    {
        IList<Categoria> RecuperarTodasCategorias();
        void AdicionarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
        void RemoverCategoria(int id);
        Categoria RecuperarPorId(int id);
        IList<Categoria> RetornarCategoriasDisponiveis();
    }
}