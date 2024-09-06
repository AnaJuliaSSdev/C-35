namespace AutoMapperReflection;

public class A
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = "default value of A"; 

    public override string? ToString()
    {
        return "name: " + this.Name + " id: " + this.Id + " description: " + this.Description;
    }
}