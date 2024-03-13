namespace DesafiosLogica
{
    class SearchName
    {
        public void NameSearch()
        {
            string[] names = { "Walter", "Jesse", "Jane", "Gustavo", "Skyler",
                "Saul", "Mike", "Hank", "Tuco", "Gale", "Tortuga" };

            Console.Write("Tip:try characters from Breaking Bad ");
            Console.Write("\nEnter a name to search: ");
            string searchText = Console.ReadLine();

            bool nameExists = Array.Exists(names, name => name.Equals(searchText, StringComparison.OrdinalIgnoreCase));

            if (nameExists)
            {
                Console.WriteLine($"The name '{searchText}' exists in the array!");
            }
            else
            {
                Console.WriteLine($"The name '{searchText}' does not exist in the array!");
            }

            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}