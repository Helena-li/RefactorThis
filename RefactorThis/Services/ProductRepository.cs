using Microsoft.EntityFrameworkCore;
using RefactorThis.Domain;
using RefactorThis.Exceptions;
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
        return await _context.Product.ToListAsync();
    }

    public async Task<Product> GetProduct(Guid id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product is null)
        {
            throw new NotFoundException($"Entity Product with Id: ({id}) was not found.");
        }

        return product;
    }

    public async Task<IEnumerable<Product>> GetProductsByName(string name)
    {
        return await _context.Product.Where(x => 
            x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Product.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        if (!IsProductExisted(product.Id))
        {
            throw new NotFoundException($"Entity Product with Id: ({product.Id}) was not found.");
        }
        
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return product;
    }

    public async Task DeleteProduct(Guid id)
    {
        var productEntity = await GetProduct(id);
        if (productEntity is null)
        {
            throw new NotFoundException($"Entity Product with Id: ({id}) was not found.");
        }

        var options = _context.ProductOption.Where(x => x.ProductId == id);
        _context.ProductOption.RemoveRange(options);
        _context.Product.Remove(productEntity);
        await _context.SaveChangesAsync();
    }

    private bool IsProductExisted(Guid id)
    {
        return  _context.Product.Any(x => x.Id == id);
    }
}