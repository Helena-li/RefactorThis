using System.ComponentModel.DataAnnotations;
using RefactorThis.Domain;
using RefactorThis.Interfaces;
using RefactorThis.Models;

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

    public Task<Product> GetProduct(Guid id)
    {
        if (string.IsNullOrEmpty(id.ToString()))
        {
            throw new ValidationException("id is invalid");
        }
        
        return _productRepository.GetProduct(id);
    }

    public Task<IEnumerable<Product>> GetProductsByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ValidationException("Name can't be empty");
        }
        
        return _productRepository.GetProductsByName(name);
    }

    public Task CreateProduct(ProductModel product)
    {
        var productDto = MapProduct(product);
        return _productRepository.CreateProduct(productDto);
    }

    private Product MapProduct(ProductModel product)
    {
        return new Product()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            DeliveryPrice = product.DeliveryPrice
        };
    }

    public Task<Product> UpdateProduct(ProductModel product)
    {
        var productDto = MapProduct(product);
        return _productRepository.UpdateProduct(productDto);
    }

    public Task DeleteProduct(Guid id)
    {
        return _productRepository.DeleteProduct(id);
    }
}