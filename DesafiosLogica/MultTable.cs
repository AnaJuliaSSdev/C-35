namespace DesafiosLogica
{
    class MultTable
    {
        public void GenerateMultTable()
        {
            Console.Write("Enter a number to see its multiplication table: ");
            double number = double.Parse(Console.ReadLine());

            Console.WriteLine($"\n\nMultiplication table of {number}:\n\n");

            for (int i = 1; i <= 10; i++)
            {
                double result = number * i;
                Console.WriteLine($"{number} x {i} = {result}");
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }

}