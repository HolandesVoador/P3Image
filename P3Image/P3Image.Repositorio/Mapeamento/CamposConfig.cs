
using System.Data.Entity.ModelConfiguration;
using P3Image.Dominio;

namespace P3Image.Repositorio.Mapeamento
{
    public class CamposConfig : EntityTypeConfiguration<Campos>
    {
        public CamposConfig()
        {
            ToTable("Campos");

            HasKey(p => p.Id);

            Property(p => p.Ordem)
                .HasColumnName("Ordem")
                .IsRequired();
            
            Property(p => p.Argumento)
                .HasColumnName("Argumento");

            Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();
            
            Property(p => p.Tipo)
                .HasColumnName("Tipo")
                .IsRequired();
        }
    }
}
