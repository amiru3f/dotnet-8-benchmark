namespace test;
using System.Text.Json.Serialization;
public class User
{
    public string Name { set; get; }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(User))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}