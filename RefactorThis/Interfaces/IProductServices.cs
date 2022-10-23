using RefactorThis.Entities;

namespace RefactorThis.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
}