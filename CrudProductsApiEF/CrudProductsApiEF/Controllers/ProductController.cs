using CrudProductsApiEF.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Product;

namespace CrudProductsApiEF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto productDto)
    {
        return await _productService.CreateProductAsync(productDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _productService.GetAllProductsAsync(skip, take);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        return await _productService.GetProductByIdAsync(id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductDto productDto)
    {
        return await _productService.UpdateProductAsync(productDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        return await _productService.DeleteProductAsync(id);
    }
}
