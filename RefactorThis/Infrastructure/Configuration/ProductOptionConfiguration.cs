using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactorThis.Entities;

namespace RefactorThis.Infrastructure.Configuration;

public class ProductOptionConfiguration: IEntityTypeConfiguration<ProductOption>
{
    public void Configure(EntityTypeBuilder<ProductOption> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnType("varchar(36)");

        builder.Property(e => e.ProductId).HasColumnType("varchar(36)");

        builder.Property(e => e.Name).HasMaxLength(100);

        builder.Property(e => e.Description).HasMaxLength(500);
    }
}