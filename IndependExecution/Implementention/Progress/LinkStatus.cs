namespace IndependExecution.Implementention.Progress
{
    public class LinkStatus
    {
        public LinkStatus(string id,
            string sourceId,
            string targetId,
            string sourceMapLink,
            string targetMapLink)
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
        public string SourceMapLink { get; }
        public string TargetMapLink { get; }

        public override string ToString()
        {
            return $"{SourceId} ---> {TargetId}";
        }
    }
}