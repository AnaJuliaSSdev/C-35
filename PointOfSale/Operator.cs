using System.Globalization;

namespace PointOfSale
{
    internal class Operator
    {
        private List<string> paymentMethods;
        private List<Product> products;
        private Order? currentOrder;

        public Operator(string csvPath)
        {
            paymentMethods = new List<string> { "Money", "Card" };
            products = new List<Product>();
            LoadProductsFromCSV(csvPath);
            currentOrder = null;
        }

        public void Run()
        {
            int option;

            do
            {
                Console.Clear();
                DisplayLogo();
                DisplayMenu();

                Console.Write("\nEnter your option: ");
                string userInput = Console.ReadLine()!;

                if (int.TryParse(userInput, out option))
                {
                    ProcessOption(option);
                }
                else
                {
                    Console.WriteLine("\nInvalid option. Please enter a valid option.");
                    PressAnyKey();
                }
            } while (option != -1);
        }

        private void ProcessOption(int option)
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
                    Console.WriteLine("You choose an invalid option.");
                    break;
            }
        }

        private void StartOrder()
        {
            currentOrder = new Order();
            Console.Clear();
            DisplayTitleOfOptions("Start a new order");
            Console.WriteLine("A new order has been started. Return to the menu to add products to this order!\n");
            PressAnyKey();
        }

        void FinishCurrentOrder()
        {
            Console.Clear();
            double total = currentOrder!.totalValue;
            DisplayTitleOfOptions("Finish order");
            Console.WriteLine($"Your order total was: {total}");
            Console.WriteLine("\nWhat is the payment method?\n");

            foreach (string paymentMethod in paymentMethods)
            {
                int index = paymentMethods.IndexOf(paymentMethod);
                Console.WriteLine($"{index}.{paymentMethod}");
            }

            int indexOfPaymentMethod;
            while (true)
            {
                Console.Write("\nEnter the payment method index: ");
                if (!int.TryParse(Console.ReadLine(), out indexOfPaymentMethod) || indexOfPaymentMethod < 0 || indexOfPaymentMethod >= paymentMethods.Count)
                {
                    Console.WriteLine("\nInvalid payment method index. Please enter a valid index.");
                }
                else
                {
                    break;
                }
            }

            if (paymentMethods[indexOfPaymentMethod] == "Money")
            {
                double amount;
                while (true)
                {
                    Console.WriteLine("Enter the amount paid by the customer in cash:");
                    if (!double.TryParse(Console.ReadLine(), out amount) || amount < total)
                    {
                        Console.WriteLine("\nInvalid amount. Please enter a valid amount equal to or greater than the total.");
                    }
                    else
                    {
                        break;
                    }
                }
                CashRegister.CalculateChange(total, amount);
            }

            Console.WriteLine("\nOrder completed successfully!");
            currentOrder!.FinishOrder(paymentMethods[indexOfPaymentMethod]);
            currentOrder = null;
            PressAnyKey();
        }

        void CheckProductStock()
        {
            Console.Clear();
            DisplayTitleOfOptions("Check stock of a product");
            Console.WriteLine("Enter the id of the item you want to check the stock:");

            if (int.TryParse(Console.ReadLine(), out int idProduct))
            {
                Product? product = FindProductById(idProduct);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                }
                else
                {
                    Console.WriteLine($"Current stock of {product.Name}: {product.Stock}");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid product ID. Please enter a valid ID.");
            }
            PressAnyKey();
        }

        private void AddItemToOrder()
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

            Product? product = FindProductById(idProduct);
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

            if (amount > product.Stock)
            {
                Console.WriteLine($"Insufficient quantity of {product.Name} in stock.");
                PressAnyKey();
                return;
            }

            currentOrder!.AddProduct(product, amount);
            products.Add(product);
            Console.WriteLine($"({amount}){product.Name} added successfully!");
            PressAnyKey();
        }

        private void DisplayCurrentOrder()
        {
            Console.Clear();
            DisplayTitleOfOptions("View current order");
            currentOrder!.DisplayProducts();
            PressAnyKey();
        }

        private void DisplayLogo()
        {
            Console.WriteLine(@"
                ▒█▀▀█ ▒█▀▀▀█ ▀█▀ ▒█▄░▒█ ▀▀█▀▀ 　 ▒█▀▀▀█ ▒█▀▀▀ 　 ▒█▀▀▀█ ░█▀▀█ ▒█░░░ ▒█▀▀▀ 
                ▒█▄▄█ ▒█░░▒█ ▒█░ ▒█▒█▒█ ░▒█░░ 　 ▒█░░▒█ ▒█▀▀▀ 　 ░▀▀▀▄▄ ▒█▄▄█ ▒█░░░ ▒█▀▀▀ 
                ▒█░░░ ▒█▄▄▄█ ▄█▄ ▒█░░▀█ ░▒█░░ 　 ▒█▄▄▄█ ▒█░░░ 　 ▒█▄▄▄█ ▒█░▒█ ▒█▄▄█ ▒█▄▄▄ 
            ");
            Console.WriteLine("Welcome to the DB sales point!");
        }

        private void DisplayMenu()
        {
            DisplayTitleOfOptions("Main Menu");
            Console.WriteLine("Enter 1 to start a order");
            Console.WriteLine("Enter 2 to add a item to an order");
            Console.WriteLine("Enter 3 to view the current order");
            Console.WriteLine("Enter 4 to finish the current order");
            Console.WriteLine("Enter 5 to check current product stock");
            Console.WriteLine("Enter -1 to exit");
        }

        private void DisplayTitleOfOptions(string title)
        {
            int titleLength = title.Length;
            string asterisks = string.Empty.PadLeft(titleLength, '*');
            Console.WriteLine(asterisks);
            Console.WriteLine(title);
            Console.WriteLine(asterisks + "\n");
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\n\nPress any key to return to the main menu");
            Console.ReadKey();
        }
        private Product? FindProductById(int id)
        {
            foreach (Product product in products)
            {
                if (product.Code == id)
                {
                    return product;
                }
            }
            return null;
        }

        private void LoadProductsFromCSV(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    string[] data = line.Split(',');
                    int code = int.Parse(data[0]);
                    string name = data[1];
                    double price = double.Parse(data[2], CultureInfo.InvariantCulture);
                    int stock = int.Parse(data[3]);
                    products.Add(new Product(code, name, price, stock));
                }
            }
        }
    }
}
