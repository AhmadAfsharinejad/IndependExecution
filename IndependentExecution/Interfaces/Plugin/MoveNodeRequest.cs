namespace IndependentExecution.Interfaces.Plugin
{
    public record MoveNodeRequest
    {
        public MoveNodeRequest(string nodeId, string location)
        {
            NodeId = nodeId;
            Location = location;
        }

        public string NodeId { get; }
        public string Location { get; }
    }
}