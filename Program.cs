using test;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Logging.AddConsole();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, SourceGenerationContext.Default);
});

var app = builder.Build();

app.MapGet("/", () => new User() { Name = "Some Name" });


Console.WriteLine($"Is Native Aot Enabled: {!RuntimeFeature.IsDynamicCodeSupported}");
app.Run();
