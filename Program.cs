using test;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Logging.AddConsole();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, SourceGenerationContext.Default);
});

var app = builder.Build();

app.MapGet("/", () =>
{
    var user = new User()
    {
        Name = "Some Name",
        Children = new List<Child>()
    };

    for (int i = 0; i < 1000; i++)
    {
        var child = new Child();
        child.LeafChildren = new List<LeafChild>();

        for (int j = 0; j < 200; j++)
        {
            child.LeafChildren.Add(new LeafChild());
        }

        user.Children.Add(child);
    }

    return user;
});


Console.WriteLine($"Is Native Aot Enabled: {!RuntimeFeature.IsDynamicCodeSupported}");
app.Run();
