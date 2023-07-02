
using System.Text.Json.Serialization;

public class Person
{
    public Person(string name)
    {
        this.Name = name;
    }
    public string Name { set; get; }
}


[JsonSerializable(typeof(Person))]
public partial class DefaultJsonContext : JsonSerializerContext { }