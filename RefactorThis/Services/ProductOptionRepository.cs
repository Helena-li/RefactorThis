using Microsoft.EntityFrameworkCore;
using RefactorThis.Domain;
using RefactorThis.Exceptions;
using RefactorThis.Infrastructure;
using RefactorThis.Interfaces;

namespace RefactorThis.Services;

public class ProductOptionRepository: IProductOptionRepository
{
    private readonly ProductDbContext _context;
    public ProductOptionRepository(ProductDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductOption>> GetProductOptionsByProductId(Guid id)
    {
        var result = await _context.ProductOption.
            Where(x => x.ProductId == id).ToListAsync();
        return result;
    }

    public async Task<ProductOption> GetProductOptionById(Guid id)
    {
        var productOption = await _context.ProductOption.FindAsync(id);
        if (productOption is null)
        {
            throw new NotFoundException($"Entity ProductOption with Id: ({id}) was not found.");
        }

        return productOption;
    }

    public async Task CreateProductOption(ProductOption productOption)
    {
        await _context.ProductOption.AddAsync(productOption);
        await _context.SaveChangesAsync();
    }

    public async Task<ProductOption> UpdateProductOption(ProductOption productOption)
    {
        if (!IsProductOptionExisted(productOption.Id))
        {
            throw new NotFoundException($"Entity ProductOption with Id: ({productOption.Id}) was not found.");
        }
        
        _context.Entry(productOption).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return productOption;
    }

    public async Task DeleteProductOption(Guid id)
    {
        var productOptionEntity = await GetProductOptionById(id);
        if (productOptionEntity is null)
        {
            throw new NotFoundException($"Entity ProductOption with Id: ({id}) was not found.");
        }
        
        _context.ProductOption.Remove(productOptionEntity);
        await _context.SaveChangesAsync();
    }
    
    private bool IsProductOptionExisted(Guid id)
    {
        return  _context.ProductOption.Any(x => x.Id == id);
    }
}