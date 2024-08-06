using Microsoft.AspNetCore.Mvc;
using Models.Dto.Product;

namespace CrudProductsApiEF.Service.Interfaces;

public interface IProductService
{
    Task<IActionResult> CreateProductAsync(CreateProductDto productDto);
    Task<IActionResult> GetProductByIdAsync(int id);
    Task<IActionResult> GetAllProductsAsync(int skip, int take);
    Task<IActionResult> UpdateProductAsync(UpdateProductDto productDto); 
    Task<IActionResult> DeleteProductAsync(int id);
}
