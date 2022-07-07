#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record LinkStatus
    {
        public LinkId Id { get; init;}
        public PluginId SourceId { get; init;}
        public PluginId TargetId { get; init;}
        public PortId? SourcePortId { get; init; }
        public PortId? TargetPortId { get; init;}

        public override string ToString()
        {
            return $"{SourceId} ---> {TargetId}";
        }
    }
}