namespace DesafiosLogica
{
    class Calculate
    {
        public void CalculateTwoNumbers()
        {
            Console.Write("Enter the first value: ");
            double valueOne = double.Parse(Console.ReadLine()!);

            Console.Write("Enter the second value: ");
            double valueTwo = double.Parse(Console.ReadLine()!);

            Console.WriteLine("\n\nSum: " + (valueOne + valueTwo));
            Console.WriteLine("Subtraction: " + (valueOne - valueTwo));
            Console.WriteLine("Multiplication: " + (valueOne * valueTwo));
            Console.WriteLine("Division: " + ( valueTwo == 0 ? "Cannot divid by zero." : (valueOne / valueTwo)) );

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
