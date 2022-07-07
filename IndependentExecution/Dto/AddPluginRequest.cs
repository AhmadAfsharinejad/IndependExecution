#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record AddPluginRequest
    {
        public PluginId Id { get; set; }
        public PluginTypeId TypeId { get; set; }
        public string Location { get; set; }
    }
}
