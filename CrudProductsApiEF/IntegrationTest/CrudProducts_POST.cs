
using Models.Dto.Product;
using System.Net;
using System.Net.Http.Json;

namespace IntegrationTests;

public class CrudProducts_POST : IClassFixture<CrudProductsWebApplicationFactory>
{
    private readonly CrudProductsWebApplicationFactory app;

    public CrudProducts_POST(CrudProductsWebApplicationFactory app)
    {
        this.app = app;
    }

    [Fact]
    public async Task POST_Product_With_Success()
    {
        //Arrange
        var product = new CreateProductDto { Name = "Product1", Category = "Category1", Perishable = true, Description = "Some product", Price = 10.00M };

        using var client = app.CreateClient();
        //Act
        var result = await client.PostAsJsonAsync("api/product", product);

        //Assert
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}
