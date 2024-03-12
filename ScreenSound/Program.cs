namespace ScreenSound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string welcomeMessage = "Welcome to Screen Sound!\n";

            Dictionary<string, List<double>> listOfBands = new Dictionary<string, List<double>>();
            listOfBands.Add("Megadeth", new List<double> { 10, 9.8 });
            listOfBands.Add("Slayer", new List<double> { 10, 10 });

            void DisplayLogo()
            {
                Console.WriteLine(@"
                ▒█▀▀▀█ █▀▀ █▀▀█ █▀▀ █▀▀ █▀▀▄ 　 ▒█▀▀▀█ █▀▀█ █░░█ █▀▀▄ █▀▀▄ 
                ░▀▀▀▄▄ █░░ █▄▄▀ █▀▀ █▀▀ █░░█ 　 ░▀▀▀▄▄ █░░█ █░░█ █░░█ █░░█ 
                ▒█▄▄▄█ ▀▀▀ ▀░▀▀ ▀▀▀ ▀▀▀ ▀░░▀ 　 ▒█▄▄▄█ ▀▀▀▀ ░▀▀▀ ▀░░▀ ▀▀▀░ 
                ");
                Console.WriteLine(welcomeMessage);
            }

            void DisplayMenuOptions()
            {
                Console.Clear();
                DisplayLogo();
                Console.WriteLine("Enter 1 to register a band");
                Console.WriteLine("Enter 2 to list all bands");
                Console.WriteLine("Enter 3 to rate a band");
                Console.WriteLine("Enter 4 to display the average of a band");
                Console.WriteLine("Enter -1 to exit");
                Console.Write("\nEnter your option: ");
                string option = Console.ReadLine()!;
                int optionNumeric = int.Parse(option);

                switch (optionNumeric)
                {
                    case 1:
                        RegisterBand();
                        break;
                    case 2:
                        ListAllBands();
                        break;
                    case 3:
                        RateBand();
                        break;
                    case 4:
                        DisplayTheAvarageOfABand();
                        break;
                    case -1:
                        Console.WriteLine("Bye xoxo");
                        break;
                    default:
                        Console.WriteLine("You choose an invalid option.");
                        break;
                }
            }

            void RegisterBand()
            {
                Console.Clear();
                DisplayTitleOfOptions("Register of bands");
                Console.Write("Type the name of the band: ");

                string bandsName = Console.ReadLine()!;
                listOfBands.Add(bandsName, new List<double>());

                Console.WriteLine($"The band {bandsName} was registered!");
                Thread.Sleep(1000);
                DisplayMenuOptions();
            }

            void ListAllBands()
            {
                Console.Clear();
                DisplayTitleOfOptions("Displaying all registered bands:");

                foreach (string band in listOfBands.Keys)
                {
                    Console.WriteLine($"Band: {band}");
                }

                PressAnyKey();
            }

            void DisplayTitleOfOptions(string title)
            {
                int titleLength = title.Length;
                string asterisks = string.Empty.PadLeft(titleLength, '*');
                Console.WriteLine(asterisks);
                Console.WriteLine(title);
                Console.WriteLine(asterisks + "\n");
            }

            void RateBand()
            {
                Console.Clear();
                DisplayTitleOfOptions("Rate a band");
                Console.WriteLine("\nEnter the name of the band you want to evaluate: ");
                string bandsName = Console.ReadLine()!;
                if (listOfBands.ContainsKey(bandsName))
                {
                    Console.Write("\n**Note: use a comma for floating-point numbers**\n");
                    Console.Write($"\nWhat rating the band {bandsName} deserve? ");
                    double rate = double.Parse(Console.ReadLine()!);
                    listOfBands[bandsName].Add(rate);
                    Console.WriteLine($"\nThe rating of {rate:F1} for the band {bandsName} has been successfully recorded!");
                    Thread.Sleep(2000);
                    DisplayMenuOptions();
                }
                else
                {
                    Console.WriteLine($"The band {bandsName} was not found\n");
                    PressAnyKey();
                }
            }

            void DisplayTheAvarageOfABand()
            {
                Console.Clear();
                DisplayTitleOfOptions("Display avarage of a band");
                Console.WriteLine("\nEnter the name of the band you want to know the average: ");
                string bandsName = Console.ReadLine()!;
                if (listOfBands.ContainsKey(bandsName))
                {
                    Console.WriteLine($"\nThe avarage of this band is: {listOfBands[bandsName].Average()}");
                }
                else
                {
                    Console.WriteLine($"\nThe band {bandsName} was not found\n");
                }

                PressAnyKey();
            }

            void PressAnyKey()
            {
                Console.WriteLine("\n\nPress any key to return to the main menu");
                Console.ReadKey();
                DisplayMenuOptions();
            }

            DisplayMenuOptions();

        }
    }
}
