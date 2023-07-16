namespace Net8Benchmark;
using System.Text.Json.Serialization;

public record Result
{
    public string? Message { set; get; } = "Hello world!";
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Result))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}