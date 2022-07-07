#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record MovePluginRequest
    {
        public string PluginId { get; init; }
        public string Location { get; init;}
    }
}