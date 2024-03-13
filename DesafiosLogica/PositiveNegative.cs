namespace DesafiosLogica
{
    class PositiveNegative
    {
        public void VerifyPositiveOrNegative()
        {
            Console.Write("Enter a number: ");
            double number = double.Parse(Console.ReadLine());

            string result = (number > 0) ? "positive" : (number < 0) ? "negative" : "zero";

            Console.WriteLine($"\n\nThe number is {result}.");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
