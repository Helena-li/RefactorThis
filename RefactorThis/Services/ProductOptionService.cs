using RefactorThis.Domain;
using RefactorThis.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Services;

public class ProductOptionService: IProductOptionService
{
    private readonly IProductOptionRepository _productOptionRepository;
    public ProductOptionService(IProductOptionRepository productOptionRepository)
    {
        _productOptionRepository = productOptionRepository;
    }
    
    public Task<IEnumerable<ProductOption>> GetProductOptionsByProductId(Guid id)
    {
        return _productOptionRepository.GetProductOptionsByProductId(id);
    }

    public Task<ProductOption> GetProductOptionById(Guid id)
    {
        return _productOptionRepository.GetProductOptionById(id);
    }

    public Task CreateProductOption(ProductOptionModel productOption)
    {
        var optionDto = MapOption(productOption);
        return _productOptionRepository.CreateProductOption(optionDto);
    }

    public Task<ProductOption> UpdateProductOption(ProductOptionModel productOption)
    {
        var optionDto = MapOption(productOption);
        return _productOptionRepository.UpdateProductOption(optionDto);
    }

    private ProductOption MapOption(ProductOptionModel productOption)
    {
        return new ProductOption()
        {
            Id = productOption.Id,
            ProductId = productOption.ProductId,
            Name = productOption.Name,
            Description = productOption.Description
        };
    }

    public Task DeleteProductOption(Guid id)
    {
        return _productOptionRepository.DeleteProductOption(id);
    }
}