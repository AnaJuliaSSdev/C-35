namespace PointOfSale
{
    internal class CashRegister
    {
        private static List<double> denominations = new List<double> { 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.25, 0.1, 0.05, 0.01 };

        public static void CalculateChange(double totalAmount, double amountPaid)
        {
            if (amountPaid < totalAmount)
            {
                Console.WriteLine("Error: The amount paid is less than the total purchase amount.");
                return;
            }

            double changeAmount = amountPaid - totalAmount;
            Console.WriteLine($"Change to be returned: $ {changeAmount:F2}");

            Console.WriteLine("Change breakdown:");

            foreach (double denomination in denominations)
            {
                if (changeAmount >= denomination)
                {
                    int count = (int)(changeAmount / denomination);
                    changeAmount -= count * denomination;
                    if (denomination >= 1)
                    {
                        Console.WriteLine($"$ {denomination:F2}: {count} bill{(count > 1 ? "s" : "")}");
                    }
                    else
                    {
                        Console.WriteLine($"$ {denomination:F2}: {count} coin{(count > 1 ? "s" : "")}");
                    }
                }
            }
        }
    }
}
