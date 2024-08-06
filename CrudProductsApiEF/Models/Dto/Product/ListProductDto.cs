using Models.Dto.Subcategory;

namespace Models.Dto.Product;

public class ListProductDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty ;

    public string Category { get; set; } = string.Empty;

    public bool Perishable { get; set; }

    public ICollection<ListSubcategoryDto>? SubCategories { get; set; } = [];
}