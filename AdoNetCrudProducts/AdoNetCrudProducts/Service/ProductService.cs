using AdoNetCrudProducts.DB;
using AdoNetCrudProducts.Models;

namespace AdoNetCrudProducts.Service;

public static class ProductService
{
    public static void ListAllProducts()
    {
        var products = ProductDAL.GetAllProducts();
        Console.WriteLine("=== Products list ===");
        foreach (var product in products)
        {
            Console.WriteLine($"\nId: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category}, Subcategory: {product.Subcategory}, Perishable: {product.Perishable}, Description: {product.Description}");
        }
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    public static void AddNewProduct()
    {
        try
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Category: ");
            string category = Console.ReadLine();
            Console.Write("Subcategory: ");
            string subcategory = Console.ReadLine();
            Console.Write("Perishable (true/false): ");
            bool perishable = bool.Parse(Console.ReadLine());

            Product product = new(name, description, category, subcategory, perishable, price);
            ProductDAL.AddProduct(product);

            Console.WriteLine("Product added successfully! Press any key to return to menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }

    public static void UpdateExistingProduct()
    {
        try
        {
            Console.Write("Product ID to be updated: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Category: ");
            string category = Console.ReadLine();
            Console.Write("Subcategory: ");
            string subcategory = Console.ReadLine();
            Console.Write("Perishable (true/false): ");
            bool perishable = bool.Parse(Console.ReadLine());

            Product product = new(name, description, category, subcategory, perishable, price)
            {
                Id = id
            };
            ProductDAL.UpdateProduct(product);

            Console.WriteLine("Product updated successfully! Press any key to return to menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }

    public static void DeleteProduct()
    {
        try
        {
            Console.Write("Product ID to be deleted: ");
            int id = int.Parse(Console.ReadLine());

            ProductDAL.DeleteProduct(id);

            Console.WriteLine("Product deleted successfully! Press any key to return to the menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }

    public static void FilterProducts()
    {
        try
        {
            Console.Write("Name (or press enter to continue): ");
            string name = Console.ReadLine();
            Console.Write("Category (or press enter to continue): ");
            string category = Console.ReadLine();
            Console.Write("Subcategory (or press enter to continue): ");
            string subcategory = Console.ReadLine();
            Console.Write("Minimum price (or press enter to continue): ");
            string minPriceInput = Console.ReadLine();
            double? minPrice = string.IsNullOrEmpty(minPriceInput) ? (double?)null : Convert.ToDouble(minPriceInput);
            Console.Write("Maximum price (or press enter to continue): ");
            string maxPriceInput = Console.ReadLine();
            double? maxPrice = string.IsNullOrEmpty(maxPriceInput) ? (double?)null : Convert.ToDouble(maxPriceInput);
            Console.Write("Perishable (true/false, or press enter to continue): ");
            string perishableInput = Console.ReadLine();
            bool? perishable = string.IsNullOrEmpty(perishableInput) ? (bool?)null : Convert.ToBoolean(perishableInput);

            var products = ProductDAL.FilterProducts(name, subcategory, category, minPrice, maxPrice, perishable);
            Console.WriteLine("=== Filtered products ===");
            foreach (var product in products)
            {
                Console.WriteLine($"\nId: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category: {product.Category}, Subcategory: {product.Subcategory}, Perishable: {product.Perishable}, Description: {product.Description}");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
