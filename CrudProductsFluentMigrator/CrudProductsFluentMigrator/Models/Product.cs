using System.ComponentModel.DataAnnotations;

namespace CrudProductsFluentMigrator.Models;

public class Product
{
    [Key]
    public long Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;
    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
}
