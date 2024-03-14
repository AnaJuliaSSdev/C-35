namespace Challenge2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the width of the rectangle: ");
            double width = double.Parse(Console.ReadLine()!);

            Console.Write("Enter the height of the rectangle: ");
            double height = double.Parse(Console.ReadLine()!);

            Rectangle rectangle = new Rectangle(width, height);

            double area = rectangle.CalculateArea();
            Console.WriteLine("Area of the rectangle: " + area);

            double perimeter = rectangle.CalculatePerimeter();
            Console.WriteLine("Perimeter of the rectangle: " + perimeter);
        }
    }
}
