using Microsoft.EntityFrameworkCore;
using Models.Models;
using StockApp.Models.Models;

namespace CrudProductsApiEF.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<ProductSubCategory> ProductSubCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductSubCategory>().HasKey(cs => new { cs.ProductId, cs.SubCategoryId });

        modelBuilder.Entity<ProductSubCategory>()
            .HasOne(cs => cs.Product)
            .WithMany(s => s.ProductSubCategories)
            .HasForeignKey(cs => cs.ProductId)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<ProductSubCategory>()
            .HasOne(cs => cs.SubCategory)
            .WithMany(c => c.ProductSubCategories)
            .HasForeignKey(cs => cs.SubCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        //Nesse caso, configurei para deleção em cascata pois achei coerente para o relacionamento e o contexto das entidades,
        //já que não teria sentido manter uma sucategoria que não existe em um produto, nem a referência de um relacionamento 
        //onde o produto não existe mais. 
    }
}
