using CrudProductsFluentMigrator.Models;
using CrudProductsFluentMigrator.Models.Dto;
using Dapper;
using System.Data;

namespace CrudProductsFluentMigrator.Repository;

public class ProductRepository : IProductRepository
{

    private readonly IDbConnection _dbConnection;

    public ProductRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }


    public async Task<Product> CreateProductAsync(CreateProductDto createProductDto)
    {
        var sql = "INSERT INTO Products (Name, Category, Price) VALUES (@Name, @Category, @Price); " +
                      "SELECT CAST(SCOPE_IDENTITY() AS INT);";
        var id = await _dbConnection.QuerySingleAsync<int>(sql, createProductDto);
        return new Product
        {
            Id = id,
            Name = createProductDto.Name,
            Category = createProductDto.Category,
            Price = createProductDto.Price
        };
    }

    public async Task<Product> DeleteProductAsync(int id)
    {
        var sql = "DELETE FROM Products WHERE Id = @Id";
        var result = await _dbConnection.ExecuteAsync(sql, new { Id = id });
        if (result == 0) throw new KeyNotFoundException($"Product with Id {id} not found.");
        return new Product { Id = id };
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var sql = "SELECT * FROM Products";
        return await _dbConnection.QueryAsync<Product>(sql);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var sql = "SELECT * FROM Products WHERE Id = @Id";
        var product = await  _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        return product ?? throw new KeyNotFoundException($"Product with Id {id} not found.");
    }

    public async Task<Product> UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var sql = "UPDATE Products SET Name = @Name, Category = @Category, Price = @Price WHERE Id = @Id";
        var result = await _dbConnection.ExecuteAsync(sql, new
        {
            updateProductDto.Name,
            updateProductDto.Category,
            updateProductDto.Price,
            updateProductDto.Id
        });
        if (result == 0) throw new KeyNotFoundException($"Product with Id {updateProductDto.Id} not found.");
        return new Product
        {
            Id = updateProductDto.Id,
            Name = updateProductDto.Name,
            Category = updateProductDto.Category,
            Price = updateProductDto.Price
        };
    }
}
