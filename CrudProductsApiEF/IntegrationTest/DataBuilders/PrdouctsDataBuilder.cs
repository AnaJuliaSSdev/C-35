using Bogus;
using Models.Models;

namespace IntegrationTest.DataBuilders;

public class PrdouctsDataBuilder : Faker<Product>
{
    public String Name { get; set; } = string.Empty;
    public String Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal MinPrice { get; set; } = 10;
    public decimal MaxPrice { get; set; } = 1000;
    public bool Perishable { get; set; } = false;

    public PrdouctsDataBuilder()
    {
        CustomInstantiator(f =>
        {
            var name = Name ?? "Product";
            var description = Description ?? "Random product.";
            var category = Category ?? "Category";
            decimal price = f.Random.Decimal(MinPrice, MaxPrice);
            return new Product { Name = name, Description = description, Category = category, Price = price };
        });
    }

}
