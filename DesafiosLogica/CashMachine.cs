namespace DesafiosLogica
{
    class CashMachine
    {
        public void Withdraw()
        {
            int[] notes = { 200, 100, 50, 20, 10, 5, 2 };
            int[] count = new int[notes.Length];
            int amount = getAmount();

            for (int i = 0; i < notes.Length; i++)
            {
                count[i] = amount / notes[i];
                amount %= notes[i];
            }

            Console.WriteLine("You will receive:");

            for (int i = 0; i < notes.Length; i++)
            {
                if (count[i] != 0)
                {
                    Console.WriteLine($"{count[i]} notes of {notes[i]}");
                }
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }

        private int getAmount()
        {
            Console.Write("Enter the amount to withdraw: ");
            int amount = int.Parse(Console.ReadLine());
            return amount;
        }
    }
}