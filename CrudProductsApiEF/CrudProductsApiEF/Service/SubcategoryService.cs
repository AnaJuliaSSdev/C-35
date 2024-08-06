using CrudProductsApiEF.Repository.Interfaces;
using CrudProductsApiEF.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Subcategory;
using Models.Dto.SubCategory;
using Models.Models;

namespace CrudProductsApiEF.Service;

public class SubcategoryService(ISubcategoryRepository subcategoryRepository) : ISubcategoryService
{
    private readonly ISubcategoryRepository _subCategoryRepository = subcategoryRepository;

    public async Task<IActionResult> CreateSubCategoryAsync(CreateSubcategoryDto subCategoryDto)
    {
        try
        {
            SubCategory subcategory = new() { Name = subCategoryDto.Name };
            SubCategory createdSubcategory = await _subCategoryRepository.CreateSubCategoryAsync(subcategory);
            ListSubcategoryDto listSubcategoryDto = new() { Id = createdSubcategory.Id, Name = createdSubcategory.Name };
            return new OkObjectResult(listSubcategoryDto);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

    public async Task<IActionResult> GetAllSubCategoriesAsync(int skip, int take)
    {
        try
        {
            IEnumerable<SubCategory> subcategories = await _subCategoryRepository.GetAllSubCategoriesAsync(skip, take);
            List<ListSubcategoryDto> listSubcategories = subcategories.Select(subcategory => new ListSubcategoryDto
            {
                Id = subcategory.Id,
                Name = subcategory.Name
            }).ToList();

            return new OkObjectResult(listSubcategories);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

    public async Task<IActionResult> GetSubCategoryByIdAsync(int id)
    {
        try
        {
            SubCategory? subcategory = await _subCategoryRepository.GetSubCategoryByIdAsync(id);
            if (subcategory == null) return new NotFoundObjectResult("Subcategory not found.");
            ListSubcategoryDto listSubcategoryDto = new() { Id = subcategory.Id, Name = subcategory.Name };
            return new OkObjectResult(listSubcategoryDto);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
    }

    public async Task<IActionResult> UpdateSubCategoryAsync(UpdateSubcategoryDto subCategoryDto)
    {
        try
        {
            SubCategory? existingSubCategory = await _subCategoryRepository.GetSubCategoryByIdAsync(subCategoryDto.Id);
            if (existingSubCategory == null) return new NotFoundObjectResult("Subcategory not found.");

            existingSubCategory.Name = subCategoryDto.Name;

            SubCategory updatedSubCategory = await _subCategoryRepository.UpdateSubCategoryAsync(existingSubCategory);

            ListSubcategoryDto listSubcategoryDto = new()
            {
                Id = updatedSubCategory.Id,
                Name = updatedSubCategory.Name
            };

            return new OkObjectResult(listSubcategoryDto);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    public async Task<IActionResult> DeleteSubCategoryAsync(int id)
    {
        try
        {
            var subcategory = await _subCategoryRepository.GetSubCategoryByIdAsync(id);
            if (subcategory == null) return new NotFoundObjectResult("Subcategory not found");

            await _subCategoryRepository.DeleteSubCategoryAsync(subcategory);

            return new NoContentResult();
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }
}
