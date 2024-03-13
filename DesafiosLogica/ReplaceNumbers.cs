namespace DesafiosLogica
{
    class ReplaceNumbers
    {

        public void Replace()
        {
            Console.Write("Enter the first number: ");
            int valueOne = int.Parse(Console.ReadLine()!);

            Console.Write("Enter the second number: ");
            int valueTwo = int.Parse(Console.ReadLine()!);

            Console.Write("Enter the third number: ");
            int valueThree = int.Parse(Console.ReadLine()!);

            Console.WriteLine("\n\nEntered values:");
            Console.WriteLine("valueOne: " + valueOne);
            Console.WriteLine("valueTwo: " + valueTwo);
            Console.WriteLine("valueThree: " + valueThree);

            int temp = valueTwo;
            valueTwo = valueThree;
            valueThree = valueOne;
            valueOne = temp;

            Console.WriteLine("\n\nValues after swapping:");
            Console.WriteLine("valueOne: " + valueOne);
            Console.WriteLine("valueTwo: " + valueTwo);
            Console.WriteLine("valueThree: " + valueThree);

            Console.WriteLine("\n\nPress any key to continue..."); 
            Console.ReadLine();
        }
    }
}
