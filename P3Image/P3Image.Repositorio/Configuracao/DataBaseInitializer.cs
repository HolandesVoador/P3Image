
using System.Data.Entity;
using P3Image.Dominio;

namespace P3Image.Repositorio.Configuracao
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<ContextoBanco>
    {
        protected override void Seed(ContextoBanco context)
        {
            base.Seed(context);
        }
    }
}
