namespace PointOfSale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock currentStock = new Stock();
            List<String> paymentMethods = new List<String> { "Money", "Card" };
            string csvPath = "RegisteredProducts.csv";
            List<Product> products = new List<Product>();
            DBManeger.LoadProductsFromCSV(csvPath, products, currentStock);
            Order? currentOrder = null;
            int option;

            do
            {
                Console.Clear();
                DisplayLogo();
                Console.WriteLine("Enter 1 to start a order");
                Console.WriteLine("Enter 2 to add a item to current order");
                Console.WriteLine("Enter 3 to view the current order");
                Console.WriteLine("Enter 4 to finish the current order");
                Console.WriteLine("Enter 5 to check current product stock");
                Console.WriteLine("Enter -1 to exit");

                Console.Write("\nEnter your option: ");
                string userInput = Console.ReadLine()!;

                if (int.TryParse(userInput, out option))
                {
                    if (currentOrder == null && option != 1 && option != -1 && option != 5)
                    {
                        Console.WriteLine("\nThere is no order in progress.");
                        PressAnyKey();
                    }
                    else
                    {
                        switch (option)
                        {
                            case 1:
                                StartOrder();
                                break;
                            case 2:
                                AddItemToOrder();
                                break;
                            case 3:
                                DisplayCurrentOrder();
                                break;
                            case 4:
                                FinishCurrentOrder();
                                break;
                            case 5:
                                CheckProductStock();
                                break;
                            case -1:
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid option. Please enter a valid option.");
                    PressAnyKey();
                }
            } while (option != -1);

            void CheckProductStock()
            {
                Console.Clear();
                DisplayTitleOfOptions("Check stock of a product");
                currentStock.CheckProductStock(products);
                PressAnyKey();
            }

            void FinishCurrentOrder()
            {
                Console.Clear();
                DisplayTitleOfOptions("Finish order");
                currentOrder!.FinishOrder(paymentMethods); 
                currentOrder = null;
                PressAnyKey();
            }

            void DisplayCurrentOrder()
            {
                Console.Clear();
                DisplayTitleOfOptions("View current order");
                currentOrder!.DisplayProducts();
                PressAnyKey();
            }

            void AddItemToOrder()
            {
                Console.Clear();
                DisplayTitleOfOptions("Add an item to the order");
                Console.WriteLine("Enter the ID of the item you want to add:");

                if (!int.TryParse(Console.ReadLine(), out int idProduct))
                {
                    Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                    PressAnyKey();
                    return;
                }

                Product? product = DBManeger.FindProductById(idProduct, products);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    PressAnyKey();
                    return;
                }

                Console.WriteLine($"How many {product.Name} do you want to add to the order?");
                if (!int.TryParse(Console.ReadLine(), out int amount) || amount <= 0)
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid positive integer quantity.");
                    PressAnyKey();
                    return;
                }

                if (amount > currentStock.stock[product.Code])
                {
                    Console.WriteLine($"Insufficient quantity of {product.Name} in stock.");
                    PressAnyKey();
                    return;
                }

                currentOrder!.AddProduct(product, amount, currentStock);
                products.Add(product);
                Console.WriteLine($"({amount}){product.Name} added successfully!");
                PressAnyKey();
            }

            void StartOrder()
            {
                currentOrder = new Order();
                Console.Clear();
                DisplayTitleOfOptions("Start a new order");
                Console.WriteLine("A new order has been started. Return to the menu to add products to this order!\n");
                PressAnyKey();
            }

            void DisplayLogo()
            {
                Console.WriteLine(@"
                ▒█▀▀█ ▒█▀▀▀█ ▀█▀ ▒█▄░▒█ ▀▀█▀▀ 　 ▒█▀▀▀█ ▒█▀▀▀ 　 ▒█▀▀▀█ ░█▀▀█ ▒█░░░ ▒█▀▀▀ 
                ▒█▄▄█ ▒█░░▒█ ▒█░ ▒█▒█▒█ ░▒█░░ 　 ▒█░░▒█ ▒█▀▀▀ 　 ░▀▀▀▄▄ ▒█▄▄█ ▒█░░░ ▒█▀▀▀ 
                ▒█░░░ ▒█▄▄▄█ ▄█▄ ▒█░░▀█ ░▒█░░ 　 ▒█▄▄▄█ ▒█░░░ 　 ▒█▄▄▄█ ▒█░▒█ ▒█▄▄█ ▒█▄▄▄ 

                ");
                Console.WriteLine("Welcome to the DB sales point!");
            }

            void DisplayTitleOfOptions(string title)
            {
                int titleLength = title.Length;
                string asterisks = string.Empty.PadLeft(titleLength, '*');
                Console.WriteLine(asterisks);
                Console.WriteLine(title);
                Console.WriteLine(asterisks + "\n");
            }

            void PressAnyKey()
            {
                Console.WriteLine("\n\nPress any key to return to the main menu");
                Console.ReadKey();
            }
        }
    }
}
