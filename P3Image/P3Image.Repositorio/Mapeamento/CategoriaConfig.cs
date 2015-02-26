using System.Data.Entity.ModelConfiguration;
using P3Image.Dominio;

namespace P3Image.Repositorio.Mapeamento
{
    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            ToTable("Categoria");

            Property(p => p.Id)
                .HasColumnName("CategoriaId");

            Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();

            Property(p => p.Slug)
                .HasColumnName("Slug")
                .HasMaxLength(30)
                .IsRequired();

        }
    }
}
