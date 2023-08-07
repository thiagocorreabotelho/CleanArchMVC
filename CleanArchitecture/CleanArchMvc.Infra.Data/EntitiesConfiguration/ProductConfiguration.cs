using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Description).HasMaxLength(200).IsRequired();
            builder.Property(m => m.Price).HasPrecision(10, 2);

            builder.HasOne(m => m.Category).WithMany(m => m.Product).HasForeignKey(m => m.CategoryId); // 1:N

        }
    }
}