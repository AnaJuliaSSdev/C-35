namespace DesafiosLogica
{
    class AnalyzeNumbers
    {
        public void Analyze()
        {
            int[] numbers = new int[10];
            Random randNum = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = randNum.Next(-101, 101);
            }

            Console.WriteLine("\nArray generated: ");
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }

            int evenCount = 0;
            int oddCount = 0;
            int positiveCount = 0;
            int negativeCount = 0;

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }

                if (number > 0)
                {
                    positiveCount++;
                }
                else if (number < 0)
                {
                    negativeCount++;
                }
            }

            Console.WriteLine($"\n\nEven numbers: {evenCount}");
            Console.WriteLine($"Odd numbers: {oddCount}");
            Console.WriteLine($"Positive numbers: {positiveCount}");
            Console.WriteLine($"Negative numbers: {negativeCount}");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}