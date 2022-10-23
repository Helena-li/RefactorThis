using Microsoft.EntityFrameworkCore;
using RefactorThis.Entities;
using RefactorThis.Infrastructure;
using RefactorThis.Interfaces;

namespace RefactorThis.Services;

public class ProductRepository: IProductRepository
{
    private readonly ProductDbContext _context;
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
}