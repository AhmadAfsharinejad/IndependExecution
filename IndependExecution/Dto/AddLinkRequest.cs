using IndependExecution.Interfaces.Core;

namespace IndependExecution.Dto
{
    public class AddLinkRequest
    {
        public string SourceId { get; set; }
        public IMapLink SourceMapLink { get; set; }
        
        public string TargetId { get; set; }
        public IMapLink TargetMapLink { get; set; }
    }
}