using IndependentExecution.Interfaces.Plugin;

#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record ChangeConfigRequest
    {
        public string PluginId { get; init; }
        public IPluginConfig Config { get; init; }
    }
}
