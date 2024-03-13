namespace DesafiosLogica
{
    class CommissionRate
    {
        public void CalculateAmount()
        {
            Console.Write("Enter the fixed salary amount: ");
            double fixedSalary = double.Parse(Console.ReadLine());

            Console.Write("Enter the total sales amount: ");
            double totalSales = double.Parse(Console.ReadLine());

            Console.Write("Enter the agreed commission percentage: ");
            double commissionPercentage = double.Parse(Console.ReadLine());

            double commission = (totalSales * commissionPercentage) / 100;
            double totalAmountToReceive = fixedSalary + commission;

            Console.WriteLine("\nTotal amount to receive: " + totalAmountToReceive.ToString("C"));

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }

}