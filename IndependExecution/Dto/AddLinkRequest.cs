using IndependExecution.Interfaces.Core;

namespace IndependExecution.Dto
{
    public class AddLinkRequest
    {
        public string SourceId { get; }
        public IMapLink SourceMapLink { get; }
        
        public string TargetId { get; }
        public IMapLink TargetMapLink { get; }
    }
}