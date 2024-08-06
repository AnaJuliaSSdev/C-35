using Models.Models;

namespace CrudProductsApiEF.Repository.Interfaces;

public interface IProductRepository
{
    Task<Product> CreateProductAsync(Product product);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync(int skip, int take);
    Task<Product> UpdateProductAsync(Product product);
    Task<Product> DeleteProductAsync(Product product); 
}
