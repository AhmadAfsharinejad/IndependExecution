#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record PluginState
    {
        public PluginId Id { get; }
        public string State { get; }
    }
}
