using System.Data.Entity;
using P3Image.Repositorio.Configuracao;
using P3Image.Dominio;
using P3Image.Repositorio.Mapeamento;

namespace P3Image.Repositorio
{
    public class ContextoBanco : DbContext
    {
        public ContextoBanco() : base("P3ImageConnection")
        {
            Database.SetInitializer(new DataBaseInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Campos> Campos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaConfig());
            modelBuilder.Configurations.Add(new CamposConfig());
            modelBuilder.Configurations.Add(new SubCategoriaConfig());
        }
    }
}
