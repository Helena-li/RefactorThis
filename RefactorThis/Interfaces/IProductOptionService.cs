using RefactorThis.Domain;
using RefactorThis.Models;

namespace RefactorThis.Interfaces;

public interface IProductOptionService
{
    Task<IEnumerable<ProductOption>> GetProductOptionsByProductId(Guid id);
    Task<ProductOption> GetProductOptionById(Guid id);
    Task CreateProductOption(ProductOptionModel productOption);
    Task<ProductOption> UpdateProductOption(ProductOptionModel productOption);
    Task DeleteProductOption(Guid id);
}