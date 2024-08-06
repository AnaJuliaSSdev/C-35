using Models.Models;
using StockApp.Models.Models;

namespace CrudProductsApiEF.Service.Interfaces;

public interface IProductSubCategoryService
{
    Task<IEnumerable<ProductSubCategory>> CreateProductSubCategoryAsync(Product product, ICollection<int> subCategories);
}
