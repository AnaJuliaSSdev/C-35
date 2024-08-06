using CrudProductsFluentMigrator.Models;
using CrudProductsFluentMigrator.Models.Dto;

namespace CrudProductsFluentMigrator.Repository;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> CreateProductAsync(CreateProductDto createProductDto);
    Task<Product> UpdateProductAsync(UpdateProductDto updateProductDto);
    Task<Product> DeleteProductAsync(int id);
}
