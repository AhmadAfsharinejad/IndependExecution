#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record ColumnSchema
    {
        private string Id { get; init; }
        string Name { get; init; }
        string Type { get; init; }
    }
}
