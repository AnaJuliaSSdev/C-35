using Models.Models;
using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Models;

public class ProductSubCategory
{

    [Key]
    public int ProductId { get; set; }

    [Key]
    public int SubCategoryId { get; set; }

    public Product Product { get; set; }
    public SubCategory SubCategory { get; set; }
}