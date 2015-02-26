using System.Collections.Generic;
using P3Image.Dominio;


namespace P3Image.Aplicacao
{
    public interface IServicoAplicacaoSubCategoria
    {
        IList<SubCategoria> RecuperarTodasSubCategorias();
        void AdicionarSubCategoria(SubCategoria subCategoria);
        void AtualizarSubCategoria(SubCategoria subCategoria);
        void RemoverSubCategoria(SubCategoria subCategoria);
        SubCategoria RecuperarPorId(int id);
        IList<SubCategoria> RecuperarTodasCategoriasSubCategorias();
    }
}
