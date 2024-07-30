using CrudProductsApi.Dto;
using CrudProductsApi.Models;

namespace CrudProductsApi.Repository;

public interface IProductRepository
{
    Task<int> CreateProductAsync(CreateProductDto productDto);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<int> UpdateProductAsync(UpdateProductDto productDto);
    Task<int> DeleteProductAsync(int id);
    Task<IEnumerable<Product>> FilterProductsAsync(FilterProductsDto filterProductsDto);
}
