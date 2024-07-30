using CrudProductsApi.Dto;
using CrudProductsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudProductsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;


    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync(
        [FromQuery] string? name = null,
        [FromQuery] string? description = null,
        [FromQuery] string? category = null,
        [FromQuery] string? subcategory = null,
        [FromQuery] double? minPrice = null,
        [FromQuery] double? maxPrice = null,
        [FromQuery] bool? perishable = null)
    {
        var filterDto = new FilterProductsDto
        {
            Name = name,
            Description = description,
            Category = category,
            Subcategory = subcategory,
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            Perishable = perishable
        };

        return await _productService.FilterProductsAsync(filterDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        return await _productService.GetProductByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductDto productDto)
    {
        return await _productService.CreateProductAsync(productDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync(UpdateProductDto productDto)
    {
        return await _productService.UpdateProductAsync(productDto);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProductAsync(int id)
    {
        return await _productService.DeleteProductAsync(id);
    }
}
