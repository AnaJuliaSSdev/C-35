namespace PointOfSale
{
    internal class Stock
    {
        public Dictionary<int, int> stock = new Dictionary<int, int>();

        public void DecreaseStock(int amount, int code)
        {
            stock[code] -= amount;
        }

        public void CheckProductStock(List<Product> products)
        {
            Console.WriteLine("Enter the id of the item you want to check the stock:");

            if (int.TryParse(Console.ReadLine(), out int idProduct))
            {
                Product? product = DBManeger.FindProductById(idProduct, products);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                }
                else
                {
                    Console.WriteLine($"Current stock of {product.Name}: {stock[product.Code]}");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid product ID. Please enter a valid ID.");
            }
        }
    }
}
