using Microsoft.EntityFrameworkCore;
using RefactorThis.Entities;

namespace RefactorThis.Infrastructure;

public class ProductDbContext: DbContext
{
    public ProductDbContext(DbContextOptions options): base(options)
    {
    }
    
    public virtual DbSet<ProductOption> ProductOptions { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}