using CrudProductsApi.Dto;
using CrudProductsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudProductsApi.Services;

public interface IProductService
{
    Task<IActionResult> GetProductByIdAsync(int id);
    Task<IActionResult> CreateProductAsync(CreateProductDto productDto);
    Task<IActionResult> UpdateProductAsync(UpdateProductDto productDto);
    Task<IActionResult> DeleteProductAsync(int id);
    Task<IActionResult> FilterProductsAsync(FilterProductsDto filterProductsDto);
}
