namespace DesafiosLogica
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;

            void DisplayTitleOfOptions(string title)
            {
                int titleLength = title.Length;
                string asterisks = string.Empty.PadLeft(titleLength, '*');
                Console.Clear();
                Console.WriteLine(asterisks);
                Console.WriteLine(title);
                Console.WriteLine(asterisks + "\n");
            }

            do
            {
                Console.Clear();
                Console.WriteLine(@"
                ███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
                ████╗░████║██╔════╝████╗░██║██║░░░██║
                ██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
                ██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
                ██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
                ╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░
                ");
                Console.WriteLine("1. Exercise 1");
                Console.WriteLine("2. Exercise 2");
                Console.WriteLine("3. Exercise 3");
                Console.WriteLine("4. Exercise 4");
                Console.WriteLine("5. Exercise 5");
                Console.WriteLine("6. Exercise 6");
                Console.WriteLine("7. Exercise 7");
                Console.WriteLine("8. Exercise 8");
                Console.WriteLine("9. Exercise 9");
                Console.WriteLine("10. Exercise 10");
                Console.WriteLine("11. Exercise 11");
                Console.WriteLine("12. Exercise 12");
                Console.WriteLine("13. Exercise 13");
                Console.WriteLine("14. Exercise 14");
                Console.WriteLine("-1. Exit");

                option = int.Parse(Console.ReadLine()!);

                switch (option)
                {
                    case 1:
                        DisplayTitleOfOptions("Replace numbers");
                        Exercise1();
                        break;
                    case 2:
                        DisplayTitleOfOptions("Calculate two numbers");
                        Exercise2();
                        break;
                    case 3: 
                        DisplayTitleOfOptions("Calculate commission received");
                        Exercise3();
                        break;
                    case 4:
                        DisplayTitleOfOptions("Positive or negative value");
                        Exercise4();
                        break;
                    case 5:
                        DisplayTitleOfOptions("Calculate the duration of a game");
                        Exercise5();
                        break;
                    case 6:
                        DisplayTitleOfOptions("Calculate two numbers version 2.0 xd");
                        Exercise6();
                        break;
                    case 7:
                        DisplayTitleOfOptions("Output in ascending order");
                        Exercise7();
                        break;
                    case 8:
                        DisplayTitleOfOptions("Using loops to print values");
                        Exercise8();
                        break;
                    case 9:
                        DisplayTitleOfOptions("Multiplication table generator");
                        Exercise9();
                        break;
                    case 10:
                        DisplayTitleOfOptions("Cash Machine");
                        Exercise10();
                        break;
                    case 11:
                        DisplayTitleOfOptions("Seconds converter");
                        Exercise11();
                        break;
                    case 12:
                        DisplayTitleOfOptions("Search for a name");
                        Exercise12();
                        break;
                    case 13:
                        DisplayTitleOfOptions("Odd, even or negative");
                        Exercise13();
                        break;
                    case 14:
                        DisplayTitleOfOptions("Operations with array");
                        Exercise14();
                        break;
                    case -1:
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }

                Console.WriteLine();
            } while (option != -1);

            void Exercise1()
            {
                ReplaceNumbers replaceNumbers = new();
                replaceNumbers.Replace();
            }

            void Exercise2()
            {
                Calculate calculate = new();
                calculate.CalculateTwoNumbers();
            }

            void Exercise3()
            {
                CommissionRate commissionRate = new();
                commissionRate.CalculateAmount(); 
            }

            void Exercise4()
            {
                PositiveNegative positiveNegative = new();
                positiveNegative.VerifyPositiveOrNegative();
            }

            void Exercise5()
            {
                DurationGame durationGame = new();
                durationGame.CalculateDurationGame();
            }

            void Exercise6()
            {
                Calculator calculator = new();
                calculator.Calc(); 
            }

            void Exercise7()
            {
                AscendingOrder ascendingOrder = new();
                ascendingOrder.Order();
            }

            void Exercise8()
            {
                ForWhile forWhile = new();
                forWhile.WhileAndForLooping();
            }

            void Exercise9()
            {
                MultTable multTable = new();
                multTable.GenerateMultTable();
            }

            void Exercise10()
            {
                CashMachine cashMachine = new();
                cashMachine.Withdraw(); 
            }

            void Exercise11()
            {
                SecondsConverter secondsConverter = new();
                secondsConverter.GetTime(); 
            }

            void Exercise12()
            {
                SearchName searchName = new();
                searchName.NameSearch();
            }

            void Exercise13()
            {
                AnalyzeNumbers analyzeNumbers = new();
                analyzeNumbers.Analyze(); 
            }

            void Exercise14()
            {
                ArrayOperations arrayOperations = new();
                arrayOperations.Menu(); 
            }
        }
    }
}
