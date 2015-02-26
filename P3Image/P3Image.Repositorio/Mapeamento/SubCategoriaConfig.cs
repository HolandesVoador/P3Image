
using System.Data.Entity.ModelConfiguration;
using P3Image.Dominio;

namespace P3Image.Repositorio.Mapeamento
{
    public class SubCategoriaConfig : EntityTypeConfiguration<SubCategoria>
    {
        public SubCategoriaConfig()
        {
            ToTable("SubCategoria");
            
            Property(p => p.Id)
                .HasColumnName("SubCategoriaId");

            Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();

            Property(p => p.Slug)
                .HasColumnName("Slug")
                .HasMaxLength(30)
                .IsRequired();

            HasRequired(t => t.Categoria)
                .WithMany()
                .HasForeignKey(t => t.CategoriaId);

            HasMany(p => p.Campos);

            Ignore(p => p.CamposRemovidos);
        }
    }
}
