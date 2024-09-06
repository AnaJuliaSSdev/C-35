namespace AutoMapperReflection;

public class Program
{
    private static void Main(string[] args)
    {
        A a = new A { Id = 1, Name = "Ana" };
        Console.WriteLine(a.ToString());
        B b = Mapper.Map<B>(a);
        Console.WriteLine(b.ToString());
    }
}