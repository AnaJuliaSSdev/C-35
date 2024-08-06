using Microsoft.AspNetCore.Mvc;
using Models.Dto.Subcategory;
using Models.Dto.SubCategory;

namespace CrudProductsApiEF.Service.Interfaces;

public interface ISubcategoryService
{
    Task<IActionResult> GetAllSubCategoriesAsync(int skip, int take);
    Task<IActionResult> GetSubCategoryByIdAsync(int id);
    Task<IActionResult> CreateSubCategoryAsync(CreateSubcategoryDto subCategoryDto);
    Task<IActionResult> UpdateSubCategoryAsync(UpdateSubcategoryDto subCategoryDto);
    Task<IActionResult> DeleteSubCategoryAsync(int id); 
}
