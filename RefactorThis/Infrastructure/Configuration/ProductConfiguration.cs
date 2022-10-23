using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactorThis.Entities;

namespace RefactorThis.Infrastructure.Configuration;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(e => e.Id).HasColumnType("varchar(36)");

        builder.Property(e => e.Name).HasMaxLength(100);

        builder.Property(e => e.Description).HasMaxLength(500);

        builder.Property(e => e.Price).HasColumnType("decimal(18,2)");
        
        builder.Property(e => e.DeliveryPrice).HasColumnType("decimal(18,2)");
    }
}