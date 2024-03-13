namespace DesafiosLogica
{

    class AscendingOrder
    {
        public void Order()
        {
            Console.Write("Enter the first value: ");
            double valueOne = double.Parse(Console.ReadLine());

            Console.Write("Enter the second value: ");
            double valueTwo = double.Parse(Console.ReadLine());

            Console.Write("Enter the third value: ");
            double valueThree = double.Parse(Console.ReadLine());

            double[] values = { valueOne, valueTwo, valueThree };
            Array.Sort(values);

            Console.WriteLine("\nValues in ascending order:");

            string result = string.Join(", ", values);
            Console.WriteLine(result);

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }

}