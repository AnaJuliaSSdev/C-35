using IntegrationTest.DataBuilders;
using IntegrationTests;
using Microsoft.EntityFrameworkCore;
using Models.Dto.Product;
using System.Net.Http.Json;

namespace IntegrationTest;

public class CrudProducts_GET : IClassFixture<CrudProductsWebApplicationFactory>
{
    private readonly CrudProductsWebApplicationFactory app;

    public CrudProducts_GET(CrudProductsWebApplicationFactory app)
    {
        this.app = app;
    }

    [Fact]
    public async Task GET_Product_ById()
    {
        //Arrange
        var existingProduct = app.Context.Products.FirstOrDefault();
        if (existingProduct is null)
        {
            existingProduct = new Models.Models.Product()
            {
                Name = "Product1",
                Category = "Category1",
                Perishable = true,
                Description = "Some product",
                Price = 10
            };
            app.Context.Add(existingProduct);
            app.Context.SaveChanges();

        }

        using var client = app.CreateClient();
        //Act

        var response = await client.GetFromJsonAsync<ListProductDTO>("/api/product/" + existingProduct.Id);

        //Assert
        Assert.NotNull(response);
        Assert.Equal(Math.Round(existingProduct.Price, 2), response.Price);
        Assert.Equal(existingProduct.Perishable, response.Perishable);
        Assert.Equal(existingProduct.Name, response.Name);
    }

    [Fact]
    public async Task GET_Paginated_Products()
    {
        //Arrange
        var productsDataBuilder = new PrdouctsDataBuilder();
        var productsList = productsDataBuilder.Generate(80);
        app.Context.Products.AddRange(productsList);
        app.Context.SaveChanges();

        using var client = app.CreateClient();

        int skip = 1;
        int take = 80;

        //Act
        var response = await client.GetFromJsonAsync<ICollection<ListProductDTO>>(
            $"api/product?skip={skip}&take={take}");

        //Assert 
        Assert.True(response != null);
        Assert.Equal(take, response.Count());
    }

    [Fact]
    public async Task GET_Paginated_Products_Last_Page()
    {
        //Arrange
        app.Context.Database.ExecuteSqlRaw("Delete from Products");
            
        var productsDataBuilder = new PrdouctsDataBuilder();
        var productsList = productsDataBuilder.Generate(80);
        app.Context.Products.AddRange(productsList);
        app.Context.SaveChanges();

        using var client = app.CreateClient();

        int skip = 75;
        int take = 25;

        //Act
        var response = await client.GetFromJsonAsync<ICollection<ListProductDTO>>(
            $"api/product?skip={skip}&take={take}");

        //Assert 
        Assert.True(response != null);
        Assert.Equal(5, response.Count());
    }

    [Fact]
    public async Task GET_Paginated_Products_Non_Existent_Page()
    {
        //Arrange
        app.Context.Database.ExecuteSqlRaw("Delete from Products");

        var productsDataBuilder = new PrdouctsDataBuilder();
        var productsList = productsDataBuilder.Generate(80);
        app.Context.Products.AddRange(productsList);
        app.Context.SaveChanges();

        using var client = app.CreateClient();

        int skip = 80;
        int take = 25;

        //Act
        var response = await client.GetFromJsonAsync<ICollection<ListProductDTO>>(
            $"api/product?skip={skip}&take={take}");

        //Assert 
        Assert.True(response != null);
        Assert.Empty(response);
    }
}
