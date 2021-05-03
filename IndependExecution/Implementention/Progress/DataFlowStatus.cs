using System.Collections.Generic;

namespace IndependExecution.Implementention.Progress
{
    public class DataFlowStatus
    {
        public List<NodeStatus> Nodes { get; }

        public List<LinkStatus> Links { get; }
        
        public DataFlowStatus()
        {
            this.Nodes = new List<NodeStatus>();
            Links = new List<LinkStatus>();
        }
    }
}
