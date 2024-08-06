using System.ComponentModel.DataAnnotations;

namespace Models.Dto.SubCategory;

public class UpdateSubcategoryDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
