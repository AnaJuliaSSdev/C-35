using CrudProductsApi.Dto;
using CrudProductsApi.Models;
using Dapper;
using System.Data.SqlClient;

namespace CrudProductsApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;
    private readonly string getConnection;

    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        getConnection = _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<int> CreateProductAsync(CreateProductDto productDto)
    {
        using SqlConnection con = new(getConnection);
        string sql = "INSERT INTO Products (Name, Price, Perishable, Description, Category, Subcategory) " +
                         "OUTPUT INSERTED.Id " +
                         "VALUES (@Name, @Price, @Perishable, @Description, @Category, @Subcategory)";

        return await con.QuerySingleAsync<int>(sql, productDto);
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        using SqlConnection con = new(getConnection);
        string sql = "DELETE FROM Products WHERE Id = @Id";
        await con.ExecuteAsync(sql, new { Id = id });
        return id;
    }

    public async Task<IEnumerable<Product>> FilterProductsAsync(FilterProductsDto filterProductsDto)
    {
        using SqlConnection con = new(getConnection);
        string procedureName = "FilterProducts";
        var parameters = new
        {
            filterProductsDto.Name,
            filterProductsDto.Description,
            filterProductsDto.Category,
            filterProductsDto.Subcategory,
            filterProductsDto.MinPrice,
            filterProductsDto.MaxPrice,
            filterProductsDto.Perishable
        };
        return await con.QueryAsync<Product>(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        using SqlConnection con = new(getConnection);
        string sql = "SELECT * FROM Products";
        return await con.QueryAsync<Product>(sql);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        using SqlConnection con = new(getConnection);
        string sql = "SELECT * FROM Products WHERE Id = @Id";
        return await con.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
    }

    public async Task<int> UpdateProductAsync(UpdateProductDto productDto)
    {
        using SqlConnection con = new(getConnection);

        string sql = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, " +
                     "Category = @Category, Subcategory = @Subcategory, Perishable = @Perishable " +
                     "WHERE Id = @Id";
        await con.ExecuteAsync(sql, productDto);
        return productDto.Id;
    }
}
