using System.ComponentModel.DataAnnotations;

namespace Models.Dto.Subcategory;

public class CreateSubcategoryDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
