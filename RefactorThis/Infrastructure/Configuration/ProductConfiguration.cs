using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactorThis.Domain;

namespace RefactorThis.Infrastructure.Configuration;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(e => e.Id).IsRequired();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);

        builder.Property(e => e.Description).HasMaxLength(500);

        builder.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
        
        builder.Property(e => e.DeliveryPrice).IsRequired().HasColumnType("decimal(18,2)");
    }
}