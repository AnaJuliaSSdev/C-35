using System.ComponentModel.DataAnnotations;

namespace CrudProductsFluentMigrator.Models.Dto;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Category { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
}
