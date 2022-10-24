using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RefactorThis.Domain;

namespace RefactorThis.Infrastructure.Configuration;

public class ProductOptionConfiguration: IEntityTypeConfiguration<ProductOption>
{
    public void Configure(EntityTypeBuilder<ProductOption> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).IsRequired();

        builder.Property(e => e.ProductId).IsRequired();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);

        builder.Property(e => e.Description).HasMaxLength(500);
    }
}