using Models.Models;

namespace CrudProductsApiEF.Repository.Interfaces;

public interface ISubcategoryRepository
{
    Task<SubCategory> CreateSubCategoryAsync(SubCategory subCategory);
    Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(int skip, int take);
    Task<SubCategory?> GetSubCategoryByIdAsync(int id);
    Task<IEnumerable<int>> VerifyExistingSubcategoriesAsync(ICollection<int> subCategories);
    Task<SubCategory> UpdateSubCategoryAsync(SubCategory subCategory);
    Task<SubCategory> DeleteSubCategoryAsync(SubCategory subCategory); 
}
