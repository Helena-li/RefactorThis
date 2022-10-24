using Microsoft.AspNetCore.Mvc;
using RefactorThis.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductOptionController : ControllerBase
{
    private readonly IProductOptionService _productOptionService;
    public ProductOptionController(IProductOptionService productOption)
    {
        _productOptionService = productOption;
    }
    
    // GET
    [Route("/search_by_product/{productId}")]
    [HttpGet]
    public async Task<IActionResult> GetProductOptionsByProductId(Guid productId)
    {
        return Ok(await _productOptionService.GetProductOptionsByProductId(productId)) ;
    }
    
    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetProductOptionById(Guid id)
    {
        return Ok(await _productOptionService.GetProductOptionById(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> PostProductOption(ProductOptionModel productOption)
    {
        await _productOptionService.CreateProductOption(productOption);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> PutProductOption(ProductOptionModel productOption)
    {
        return Ok(await _productOptionService.UpdateProductOption(productOption));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductOption(Guid id)
    { 
        await _productOptionService.DeleteProductOption(id);
        return Ok();
    }
}