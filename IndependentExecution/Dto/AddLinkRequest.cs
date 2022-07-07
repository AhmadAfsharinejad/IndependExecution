
#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record AddLinkRequest
    {
        public string SourceId { get; init; }
        public string? SourcePortId { get; init; }
        public string TargetId { get; init; }
        public string? TargetPortId { get; init; }
    }
}