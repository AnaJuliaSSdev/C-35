using AdoNetCrudProducts.Exceptions;
using AdoNetCrudProducts.Models;
using Microsoft.Data.SqlClient;
using System.Text;

namespace AdoNetCrudProducts.DB;

public class ProductDAL
{
    public static void AddProduct(Product product)
    {
        using var connection = new Connection().GetConnection();
        connection.Open();

        string sql = "INSERT INTO Products (Name, Price, Perishable, Description, Category, Subcategory) VALUES" +
            "(@name, @price, @perishable, @description, @category, @subcategory)";

        SqlCommand command = new(sql, connection);

        command.Parameters.AddWithValue("@name", product.Name);
        command.Parameters.AddWithValue("@price", product.Price);
        command.Parameters.AddWithValue("@perishable", product.Perishable);
        command.Parameters.AddWithValue("@description", product.Description);
        command.Parameters.AddWithValue("@category", product.Category);
        command.Parameters.AddWithValue("@subcategory", product.Subcategory);
        command.ExecuteNonQuery();
    }

    public static IEnumerable<Product> GetAllProducts()
    {
        var list = new List<Product>();
        using var connection = new Connection().GetConnection();
        connection.Open();

        string sql = "SELECT * FROM Products";
        SqlCommand command = new(sql, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader["Id"]);
            string productName = Convert.ToString(reader["Name"]);
            double price = Convert.ToDouble(reader["Price"]);
            string category = Convert.ToString(reader["Category"]);
            string description = Convert.ToString(reader["Description"]);
            string subcategory = Convert.ToString(reader["Subcategory"]);
            bool perishable = Convert.ToBoolean(reader["Perishable"]);

            var product = new Product
            {
                Id = id,
                Name = productName,
                Price = price,
                Category = category,
                Description = description,
                Subcategory = subcategory,
                Perishable = perishable
            };

            list.Add(product);
        }

        return list;
    }

    public static void UpdateProduct(Product product)
    {
        using var connection = new Connection().GetConnection();
        connection.Open();

        string checkSql = "SELECT COUNT(*) FROM Products WHERE Id = @Id";
        SqlCommand checkCommand = new(checkSql, connection);
        checkCommand.Parameters.AddWithValue("@Id", product.Id);
        int count = (int)checkCommand.ExecuteScalar();

        if (count == 0) throw new ProductNotFoundException(product.Id);

        string sql = "UPDATE Products SET Name = @Name, Description = @Description, Price = @Price, Category = @Category, Subcategory = @Subcategory, Perishable = @Perishable WHERE Id = @Id";
        SqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue("@Id", product.Id);
        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Description", product.Description);
        command.Parameters.AddWithValue("@Price", product.Price);
        command.Parameters.AddWithValue("@Category", product.Category);
        command.Parameters.AddWithValue("@Subcategory", product.Subcategory);
        command.Parameters.AddWithValue("@Perishable", product.Perishable);
        command.ExecuteNonQuery();
    }

    public static void DeleteProduct(int id)
    {
        using var connection = new Connection().GetConnection();
        connection.Open();

        string checkSql = "SELECT COUNT(*) FROM Products WHERE Id = @Id";
        SqlCommand checkCommand = new(checkSql, connection);
        checkCommand.Parameters.AddWithValue("@Id", id);
        int count = (int)checkCommand.ExecuteScalar();

        if (count == 0) throw new ProductNotFoundException(id);

        string sql = "DELETE FROM Products WHERE Id = @Id";
        SqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue("@Id", id);
        int rows = command.ExecuteNonQuery();
    }

    public static IEnumerable<Product> FilterProducts(string name = null, string subcategory = null, string category = null, double? minPrice = null, double? maxPrice = null, bool? perishable = null)
    {
        var products = new List<Product>();
        using var connection = new Connection().GetConnection();
        connection.Open();

        var sb = new StringBuilder("SELECT * FROM Products WHERE 1=1");
        var command = new SqlCommand { Connection = connection };

        if (!string.IsNullOrEmpty(name))
        {
            sb.Append(" AND Name LIKE @Name");
            command.Parameters.AddWithValue("@Name", $"%{name}%");
        }

        if (!string.IsNullOrEmpty(subcategory))
        {
            sb.Append(" AND Subcategory LIKE @Subcategory");
            command.Parameters.AddWithValue("@Subcategory", $"%{subcategory}%");
        }

        if (!string.IsNullOrEmpty(category))
        {
            sb.Append(" AND Category LIKE @Category");
            command.Parameters.AddWithValue("@Category", $"%{category}%");
        }

        if (minPrice.HasValue)
        {
            sb.Append(" AND Price >= @MinPrice");
            command.Parameters.AddWithValue("@MinPrice", minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            sb.Append(" AND Price <= @MaxPrice")    ;
            command.Parameters.AddWithValue("@MaxPrice", maxPrice.Value);
        }

        if (perishable.HasValue)
        {
            sb.Append(" AND Perishable = @Perishable");
            command.Parameters.AddWithValue("@Perishable", perishable.Value);
        }

        command.CommandText = sb.ToString();

        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            var product = new Product
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = Convert.ToString(reader["Name"]),
                Price = Convert.ToDouble(reader["Price"]),
                Category = Convert.ToString(reader["Category"]),
                Description = Convert.ToString(reader["Description"]),
                Subcategory = Convert.ToString(reader["Subcategory"]),
                Perishable = Convert.ToBoolean(reader["Perishable"])
            };

            products.Add(product);
        }

        return products;
    }
}
