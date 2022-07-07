#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record MovePluginRequest
    {
        public PluginId PluginId { get; init; }
        public string Location { get; init;}
    }
}