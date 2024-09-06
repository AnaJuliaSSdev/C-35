namespace AutoMapperReflection;

public class B
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Spec { get; set; } = "default value of B";

    public override string? ToString()
    {
        return "name: " + this.Name + " id: " + this.Id + " spec: " + this.Spec;
    }
}
