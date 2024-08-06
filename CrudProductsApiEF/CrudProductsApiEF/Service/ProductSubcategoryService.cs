using CrudProductsApiEF.Repository.Interfaces;
using CrudProductsApiEF.Service.Interfaces;
using Models.Models;
using StockApp.Models.Models;

namespace CrudProductsApiEF.Service;

public class ProductSubcategoryService : IProductSubCategoryService
{
    private readonly IProductSubCategoryRepository _productSubCategoryRepository;
    private readonly ISubcategoryRepository _subcategoryRepository;

    public ProductSubcategoryService(IProductSubCategoryRepository productSubCategoryRepository, ISubcategoryRepository subcategoryRepository)
    {
        _productSubCategoryRepository = productSubCategoryRepository;
        _subcategoryRepository = subcategoryRepository;
    }

    public async Task<IEnumerable<ProductSubCategory>> CreateProductSubCategoryAsync(Product product, ICollection<int> subCategories)
    {
        var missingIds = await _subcategoryRepository.VerifyExistingSubcategoriesAsync(subCategories);

        if (missingIds.Any())
        {
            var missingIdList = string.Join(", ", missingIds);
            throw new Exception($"Subcategories with IDs {missingIdList} don't exist.");
        }

        return await _productSubCategoryRepository.CreateProductSubcategoriesAsync(subCategories.Select(subCategoryId => new ProductSubCategory
        {
            ProductId = product.Id,
            SubCategoryId = subCategoryId
        }));
    }
}
