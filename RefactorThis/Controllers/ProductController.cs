using Microsoft.AspNetCore.Mvc;
using RefactorThis.Entities;
using RefactorThis.Interfaces;

namespace RefactorThis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController :  ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productService.GetProducts();
    }
}