using CrudProductsApiEF.Context;
using CrudProductsApiEF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace CrudProductsApiEF.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _context.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(int skip, int take)
    {
        return await _context.Products.AsQueryable().Skip(skip).Take(take)
            .Include(p =>  p.ProductSubCategories)
                .ThenInclude(psc => psc.SubCategory)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .AsQueryable()
             .Include(p => p.ProductSubCategories)
                .ThenInclude(psc => psc.SubCategory)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _context.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteProductAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}
