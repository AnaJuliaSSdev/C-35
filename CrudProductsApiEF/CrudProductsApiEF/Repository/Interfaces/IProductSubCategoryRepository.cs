using StockApp.Models.Models;

namespace CrudProductsApiEF.Repository.Interfaces;

public interface IProductSubCategoryRepository
{
    Task<IEnumerable<ProductSubCategory>> CreateProductSubcategoriesAsync(IEnumerable<ProductSubCategory> productSubCategories);
}
