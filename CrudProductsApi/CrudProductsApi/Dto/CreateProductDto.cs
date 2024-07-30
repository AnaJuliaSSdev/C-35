using System.ComponentModel.DataAnnotations;

namespace CrudProductsApi.Dto;

public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;

    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Subcategory { get; set; } = string.Empty;
    public bool Perishable { get; set; }
}
