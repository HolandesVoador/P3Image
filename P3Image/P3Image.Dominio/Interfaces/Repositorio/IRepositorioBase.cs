namespace P3Image.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntidade>
    {
        TEntidade RecuperarPorId(int id);
        void Inserir(TEntidade obj);
        void Alterar(TEntidade obj);
        void Remover(TEntidade obj);
        void Remover(int id);
    }
}
