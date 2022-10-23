using RefactorThis.Entities;

namespace RefactorThis.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
}