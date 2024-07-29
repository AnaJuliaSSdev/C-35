using System.ComponentModel.DataAnnotations;

namespace AdoNetCrudProducts.Models;

public class Product
{
    public Product(string name, string description, string category, string subcategory, bool perishable, double price)
    {
        Name = name;
        Price = price;
        Description = description;
        Category = category;
        Subcategory = subcategory;
        Perishable = perishable;
    }

    public Product() { }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Subcategory { get; set; } = string.Empty;
    public bool Perishable { get; set; }
}
