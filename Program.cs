using Net8Benchmark;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Logging.AddConsole();
builder.Services.ConfigureHttpJsonOptions(options => options.SerializerOptions.TypeInfoResolverChain.Insert(0, SourceGenerationContext.Default));

var app = builder.Build();

app.MapGet("/", () => User.CreateTestUsers());

Console.WriteLine($"Is Native Aot Enabled: {!RuntimeFeature.IsDynamicCodeSupported}");
app.Run();
