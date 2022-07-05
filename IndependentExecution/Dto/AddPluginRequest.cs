#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record AddPluginRequest
    {
        public string Id { get; set; }
        public string TypeId { get; set; }
        public string Location { get; set; }
    }
}
