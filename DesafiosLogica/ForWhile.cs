namespace DesafiosLogica
{
    class ForWhile
    {
        public void WhileAndForLooping()
        {
            int i = 1;
            Console.WriteLine("Printing values from 1 to 25 using while loop:");
            while (i <= 25)
            {
                Console.Write(i + " ");
                i++;
            }

            Console.WriteLine("\n\nPrinting values from 10 to 200, skipping by 10 using for loop:");
            for (i = 10; i <= 200; i += 10)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}

