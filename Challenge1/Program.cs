namespace Challenge1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("José", 25, "Engineer");
            Person person2 = new Person("Diogo", 25, "Joiner");

            Car car1 = new Car("Volkswagen", "Fusca 1300", 1970);
            Car car2 = new Car("Renault", "Twingo", 2002);

            car1.AssignOwner(person1);
            car2.AssignOwner(person2);

            List<Car> cars = new List<Car> { car1, car2 };

            Console.WriteLine("Cars and their owners:");
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
