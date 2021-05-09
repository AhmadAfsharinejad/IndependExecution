
namespace IndependExecution.Dto
{
    public class AddLinkRequest
    {
        public string SourceId { get; set; }
        public string SourceMapLink { get; set; }
        
        public string TargetId { get; set; }
        public string TargetMapLink { get; set; }
    }
}