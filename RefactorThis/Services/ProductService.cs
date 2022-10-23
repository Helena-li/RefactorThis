using RefactorThis.Entities;
using RefactorThis.Interfaces;

namespace RefactorThis.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<IEnumerable<Product>> GetProducts()
    {
        return _productRepository.GetProducts();
    }
}