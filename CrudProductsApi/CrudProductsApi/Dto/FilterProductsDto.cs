namespace CrudProductsApi.Dto;

public class FilterProductsDto
{
    public string? Name = null;
    public string? Description = null;
    public string? Category = null;
    public string? Subcategory = null;
    public double? MinPrice = null;
    public double? MaxPrice = null;
    public bool? Perishable = null;
}
