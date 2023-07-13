namespace test;
using System.Text.Json.Serialization;
public class User
{
    public string? Name { set; get; }
    public List<Child> Children = new();
}

public class Child
{
    public string Name { set; get; } = "Default";
    public string Lastname { set; get; } = "Default";
    public string FullName { set; get; } = "Default";

    public List<LeafChild> LeafChildren = new List<LeafChild>();

}

public class LeafChild
{
    public string Name { set; get; } = "Default";
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(Child))]
[JsonSerializable(typeof(LeafChild))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}