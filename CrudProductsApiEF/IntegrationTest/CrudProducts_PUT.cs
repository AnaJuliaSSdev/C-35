using IntegrationTests;
using Microsoft.EntityFrameworkCore;
using Models.Dto.Product;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTest;

public class CrudProducts_PUT : IClassFixture<CrudProductsWebApplicationFactory>
{
    private readonly CrudProductsWebApplicationFactory app;

    public CrudProducts_PUT(CrudProductsWebApplicationFactory app)
    {
        this.app = app;
    }


    [Fact]
    public async Task UPDATE_Product_ById()
    {
        //Arrange
        app.Context.Database.ExecuteSqlRaw("Delete from Products");
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
        var response = await client.PutAsJsonAsync($"api/product", new UpdateProductDto
        {
            Id = existingProduct.Id,
            Name = existingProduct.Name,
            Price = existingProduct.Price,
            Description = existingProduct.Description,
            Category = existingProduct.Category,
            Perishable = existingProduct.Perishable
        });

        //Assert
        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }   

}
