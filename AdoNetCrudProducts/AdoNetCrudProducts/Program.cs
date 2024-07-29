using AdoNetCrudProducts.Service;

try
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("==== MENU ====");
        Console.WriteLine("1. Create product");
        Console.WriteLine("2. List all products");
        Console.WriteLine("3. Update product");
        Console.WriteLine("4. Filter products");
        Console.WriteLine("5. Delete product");
        Console.WriteLine("6. Exit");
        Console.Write("Select an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                ProductService.AddNewProduct();
                break;
            case "2":
                ProductService.ListAllProducts();
                break;
            case "3":
                ProductService.UpdateExistingProduct();
                break;
            case "4":
                ProductService.FilterProducts();
                break;
            case "5":
                ProductService.DeleteProduct();
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Invalid option. Press any key to try again.");
                Console.ReadKey();
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}