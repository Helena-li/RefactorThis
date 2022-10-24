using Microsoft.EntityFrameworkCore;
using RefactorThis.Domain;

namespace RefactorThis.Infrastructure;

public class ProductDbContext: DbContext
{
    public ProductDbContext(DbContextOptions options): base(options)
    {
    }
    
    public virtual DbSet<ProductOption> ProductOption { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}