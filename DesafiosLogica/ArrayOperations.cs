namespace DesafiosLogica
{
    class ArrayOperations
    {
        public void Menu()
        {
            List<double> numbers = new List<double>();

            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a new number to the end of the array");
                Console.WriteLine("2. Remove a number from the array based on position");
                Console.WriteLine("3. Remove a number from the array based on its value");
                Console.WriteLine("4. Sort the numbers in ascending order");
                Console.WriteLine("5. Sort the numbers in descending order");
                Console.WriteLine("6. Sum the values of the array");
                Console.WriteLine("7. List all numbers in the array");
                Console.WriteLine("8. Exit");

                Console.Write("Choose an option: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddNumber(numbers);
                        break;
                    case 2:
                        RemoveByPosition(numbers);
                        break;
                    case 3:
                        RemoveByValue(numbers);
                        break;
                    case 4:
                        SortAscending(numbers);
                        break;
                    case 5:
                        SortDescending(numbers);
                        break;
                    case 6:
                        SumValues(numbers);
                        break;
                    case 7:
                        ListAllNumbers(numbers);
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        Console.WriteLine("\n\nPress any key to continue...");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a valid number.");
                        break;
                }

            } while (option != 8);
        }

        public void AddNumber(List<double> numbers)
        {
            Console.Clear();
            Console.Write("Enter the new number: ");
            double newNumber = double.Parse(Console.ReadLine()!);

            numbers.Add(newNumber);
            Console.WriteLine("Number added successfully!");

            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        public void RemoveByPosition(List<double> numbers)
        {
            Console.Clear();
            Console.Write("Enter the position of the number to remove: ");
            int position = int.Parse(Console.ReadLine()!);

            if (position >= 0 && position < numbers.Count)
            {
                numbers.RemoveAt(position);
                Console.WriteLine("Number removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid or unfilled position. Please enter a valid position.");
            }

            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        public void RemoveByValue(List<double> numbers)
        {
            Console.Clear();
            Console.Write("Enter the value of the number to remove: ");
            double valueToRemove = double.Parse(Console.ReadLine()!);

            int count = numbers.RemoveAll(n => n == valueToRemove);
            if (count > 0)
            {
                Console.WriteLine($"Number(s) removed successfully! ({count} occurrences)");
            }
            else
            {
                Console.WriteLine("Number not found in the array.");
            }


            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        public void SortAscending(List<double> numbers)
        {
            Console.Clear();
            numbers.Sort();
            Console.WriteLine("Numbers sorted in ascending order!");
            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        public void SortDescending(List<double> numbers)
        {
            Console.Clear();
            numbers.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine("Numbers sorted in descending order!");
            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        public void SumValues(List<double> numbers)
        {
            Console.Clear();
            double sum = numbers.Sum();
            Console.WriteLine($"Sum of the numbers: {sum}");
            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadLine();
        }

        public void ListAllNumbers(List<double> numbers)
        {
            Console.Clear();
            if (numbers.Count == 0)
            {
                Console.WriteLine("The array is empty.");
            }
            else
            {
                Console.WriteLine("Numbers in the array:");
                foreach (var number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
            Console.WriteLine("\n\nPress any key to return to the menu...");
            Console.ReadLine();
        }
    }
}
