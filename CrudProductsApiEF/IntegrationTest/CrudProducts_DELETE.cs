using IntegrationTests;
using System.Net;

namespace IntegrationTest;

public class CrudProducts_DELETE : IClassFixture<CrudProductsWebApplicationFactory>
{
    private readonly CrudProductsWebApplicationFactory app;

    public CrudProducts_DELETE(CrudProductsWebApplicationFactory app)
    {
        this.app = app;
    }

    [Fact]
    public async Task DELETE_Product_ById()
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
                Price = 10.00M
            };
            app.Context.Add(existingProduct);
            app.Context.SaveChanges();

        }

        using var client = app.CreateClient();

        //Act
        var response = await client.DeleteAsync("api/product/" +  existingProduct.Id);

        //Assert
        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}
