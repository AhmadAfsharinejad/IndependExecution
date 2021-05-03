using IndependExecution.Interfaces.Core;

namespace IndependExecution.Implementention.Progress
{
    public class LinkStatus
    {
        public LinkStatus(string id,
            string sourceId,
            string targetId,
            IMapLink sourceMapLink,
            IMapLink targetMapLink)
        {
            Id = id;
            SourceId = sourceId;
            TargetId = targetId;
            SourceMapLink = sourceMapLink;
            TargetMapLink = targetMapLink;
        }

        public string Id { get; }
        public string SourceId { get; }
        public string TargetId { get; }
        public IMapLink SourceMapLink { get; }
        public IMapLink TargetMapLink { get; }
    }
}