using CrudProductsApiEF.Context;
using CrudProductsApiEF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace CrudProductsApiEF.Repository;

public class SubcategoryRepository : ISubcategoryRepository
{
    private AppDbContext _context;

    public SubcategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SubCategory> CreateSubCategoryAsync(SubCategory subCategory)
    {
        await _context.SubCategories.AddAsync(subCategory);
        await _context.SaveChangesAsync();
        return subCategory;
    }

    public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(int skip, int take)
    {
        return await _context.SubCategories
             .AsQueryable()
             .Skip(skip)
             .Take(take)
             .ToListAsync();
    }

    public async Task<SubCategory?> GetSubCategoryByIdAsync(int id)
    {
        return await _context.SubCategories.FirstOrDefaultAsync(sc => sc.Id == id);
    }

    public async Task<IEnumerable<int>> VerifyExistingSubcategoriesAsync(ICollection<int> subCategories)
    {
        if (subCategories == null || subCategories.Count == 0) return [];

        var existingSubcategories = await _context.SubCategories
            .Where(sc => subCategories.Contains(sc.Id))
            .Select(sc => sc.Id)
            .ToListAsync();

        return subCategories.Except(existingSubcategories);
    }

    public async Task<SubCategory> UpdateSubCategoryAsync(SubCategory subCategory)
    {
        _context.SubCategories.Update(subCategory);
        await _context.SaveChangesAsync();
        return subCategory;
    }

    public async Task<SubCategory> DeleteSubCategoryAsync(SubCategory subCategory)
    {
        _context.SubCategories.Remove(subCategory);
        await _context.SaveChangesAsync();
        return subCategory; 
    }
}
