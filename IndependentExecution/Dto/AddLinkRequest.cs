
#pragma warning disable CS8618
namespace IndependentExecution.Dto
{
    public record AddLinkRequest
    {
        public string SourceId { get; set; }
        public string SourceMapLink { get; set; }
        
        public string TargetId { get; set; }
        public string TargetMapLink { get; set; }
    }
}