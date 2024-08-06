using CrudProductsApiEF.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Subcategory;
using Models.Dto.SubCategory;

namespace CrudProductsApiEF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubcategoryController : ControllerBase
{
    private readonly ISubcategoryService _subCategoryService;

    public SubcategoryController(ISubcategoryService subcategoryService)
    {
        _subCategoryService = subcategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubCategoriesAsync([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _subCategoryService.GetAllSubCategoriesAsync(skip, take);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubCategoryByIdAsync(int id)
    {
        return await _subCategoryService.GetSubCategoryByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubCategoryAsync([FromBody] CreateSubcategoryDto subCategoryDto)
    {
        return await _subCategoryService.CreateSubCategoryAsync(subCategoryDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubCategoryAsync([FromBody] UpdateSubcategoryDto subCategoryDto)
    {
        return await _subCategoryService.UpdateSubCategoryAsync(subCategoryDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubCategoryAsync(int id)
    {
        return await _subCategoryService.DeleteSubCategoryAsync(id);
    }
}
