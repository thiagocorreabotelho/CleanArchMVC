using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Seta como chave primaria da tabela
            builder.HasKey(m => m.Id);

            // Seta configuração de string/varchar
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            //Incluindo três registros.
            builder.HasData(
                    new Category(1, "Material Escolar"),
                    new Category(2, "Eletrônicos"),
                    new Category(3, "Acessórios"));
        }
    }
}