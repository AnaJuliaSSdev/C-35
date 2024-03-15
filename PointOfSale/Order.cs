namespace PointOfSale
{
    internal class Order
    {
        private Dictionary<Product, int> orderItems;
        public double totalValue { get; set; }
        private string? paymentMethod;

        public Order()
        {
            orderItems = new Dictionary<Product, int>();
            totalValue = 0;
        }

        public void AddProduct(Product product, int amount, Stock stock)
        {
            if (orderItems.ContainsKey(product))
            {
                orderItems[product] += amount;
            }
            else
            {
                orderItems.Add(product, amount);
            }
            stock.DecreaseStock(amount, product.Code);
            totalValue += product.Price * amount;
        }

        public void FinishOrder(List<String> paymentMethods)
        {
            double total = this.totalValue;
            Console.WriteLine($"Your order total was: $ {total}");
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

            string chosenPaymentMethod = paymentMethods[indexOfPaymentMethod]; 
            if (chosenPaymentMethod == "Money")
            {
                double amount;
                while (true)
                {
                    Console.WriteLine("\nEnter the amount paid by the customer in cash:");
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
            paymentMethod = chosenPaymentMethod; 
        }

        public void DisplayProducts()
        {
            foreach (var item in orderItems)
            {
                Console.WriteLine($"{item.Key.Name} (x{item.Value}): ${item.Key.Price * item.Value:F2}");
            }
            Console.WriteLine($"\n\nTotal value: ${totalValue:F2}");
        }
    }
}
