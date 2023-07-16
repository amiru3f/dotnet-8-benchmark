namespace Net8Benchmark;
using System.Text.Json.Serialization;

public record User
{
    public string? Name { set; get; } = nameof(Name);
    public List<Child> Children = new();

    public static List<User> CreateTestUsers()
    {
        List<User> users = new();

        for (int i = 0; i < 1000; i++)
        {
            var user = new User();

            for (int j = 0; j < 100; j++)
            {
                var child = new Child();

                for (int k = 0; k < 10; k++)
                {
                    child.LeafChildren.Add(new());
                }

                user.Children.Add(child);
            }

            users.Add(user);
        }

        return users;
    }
}

public record Child
{
    public string Name { set; get; } = nameof(Name);
    public string Lastname { set; get; } = nameof(Lastname);
    public string FullName { set; get; } = nameof(FullName);

    public List<LeafChild> LeafChildren = new();
}

public record LeafChild
{
    public string Name { set; get; } = nameof(Name);
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(List<User>))]
[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(Child))]
[JsonSerializable(typeof(LeafChild))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}