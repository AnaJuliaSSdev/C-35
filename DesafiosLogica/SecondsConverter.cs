namespace DesafiosLogica
{
    class SecondsConverter
    {
        public string FormatTime(int totalSeconds)
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            string formattedTime = $"{hours:D2}h:{minutes:D2}m:{seconds:D2}s";
            return formattedTime;
        }

        public void GetTime() 
        {
            Console.Write("Enter total seconds: ");
            int totalSeconds = int.Parse(Console.ReadLine());

            Console.Write(FormatTime(totalSeconds));

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }

}