using RefactorThis.Domain;

namespace RefactorThis.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(Guid id);
    Task<IEnumerable<Product>> GetProductsByName(string name);
    Task CreateProduct(Product product);
    Task<Product> UpdateProduct(Product product);
    Task DeleteProduct(Guid id);
}