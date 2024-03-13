namespace DesafiosLogica
{
    class Calculator
    {
        public void Calc()
        {
            Console.Write("Enter the first value: ");
            double valueOne = double.Parse(Console.ReadLine());

            Console.Write("Enter the second value: ");
            double valueTwo = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose the calculation to perform:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            Console.Write("Option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine($"Addition: {valueOne + valueTwo}");
                    break;
                case 2:
                    Console.WriteLine($"Subtraction: {valueOne - valueTwo}");
                    break;
                case 3:
                    Console.WriteLine($"Multiplication: {valueOne * valueTwo}");
                    break;
                case 4:
                    if (valueTwo != 0)
                        Console.WriteLine($"Division: {valueOne / valueTwo}");
                    else
                        Console.WriteLine("Cannot divide by zero.");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
