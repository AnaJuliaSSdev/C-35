using CrudProductsApiEF.Context;
using CrudProductsApiEF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using StockApp.Models.Models;

namespace CrudProductsApiEF.Repository;

public class ProductSubCategoryRepository : IProductSubCategoryRepository
{
    private readonly AppDbContext _context;

    public ProductSubCategoryRepository(AppDbContext context)
    {
        _context = context; 
    }

    public async Task<IEnumerable<ProductSubCategory>> CreateProductSubcategoriesAsync(IEnumerable<ProductSubCategory> productSubCategories)
    {
        await _context.AddRangeAsync(productSubCategories);
        await _context.SaveChangesAsync();

        return await _context.ProductSubCategories
        .Include(psc => psc.Product)
        .Include(psc => psc.SubCategory)
        .ToListAsync(); 
    }
}
