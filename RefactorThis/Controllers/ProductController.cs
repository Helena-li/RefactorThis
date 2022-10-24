using Microsoft.AspNetCore.Mvc;
using RefactorThis.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController :  ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;
    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        _logger.LogInformation("GetProducts at: {time}", DateTimeOffset.UtcNow);
        return Ok(await _productService.GetProducts()) ;
    }
    
    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        return Ok(await _productService.GetProduct(id));
    }
    
    [Route("/search")]
    [HttpGet]
    public async Task<IActionResult> GetProduct(string name)
    {
        return Ok(await _productService.GetProductsByName(name));
    }
    
    [HttpPost]
    public async Task<IActionResult> PostProduct(ProductModel product)
    {
        await _productService.CreateProduct(product);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> PutProduct(ProductModel product)
    {
        return Ok(await _productService.UpdateProduct(product));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    { 
        await _productService.DeleteProduct(id);
        return Ok();
    }
}