using RefactorThis.Domain;
using RefactorThis.Models;

namespace RefactorThis.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(Guid id);
    Task<IEnumerable<Product>> GetProductsByName(string name);
    Task CreateProduct(ProductModel product);
    Task<Product> UpdateProduct(ProductModel product);
    Task DeleteProduct(Guid id);
}