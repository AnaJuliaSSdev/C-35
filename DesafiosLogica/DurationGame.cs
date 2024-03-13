namespace DesafiosLogica
{
    class DurationGame
    {
       public void CalculateDurationGame()
        {
            Console.Write("Enter the start hour (0-23): ");
            int startHour = int.Parse(Console.ReadLine());

            Console.Write("Enter the end hour (0-23): ");
            int endHour = int.Parse(Console.ReadLine());

            int duration;
            if (endHour >= startHour)
            {
                duration = endHour - startHour;
            }
            else
            {
                duration = 24 - startHour + endHour;
            }

            Console.WriteLine($"\n\nThe duration of the game is {duration} hours.");

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}