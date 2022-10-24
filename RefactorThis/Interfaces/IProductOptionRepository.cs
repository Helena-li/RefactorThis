using RefactorThis.Domain;

namespace RefactorThis.Interfaces;

public interface IProductOptionRepository
{
    Task<IEnumerable<ProductOption>> GetProductOptionsByProductId(Guid id);
    Task<ProductOption> GetProductOptionById(Guid id);
    Task CreateProductOption(ProductOption productOption);
    Task<ProductOption> UpdateProductOption(ProductOption productOption);
    Task DeleteProductOption(Guid id);
}