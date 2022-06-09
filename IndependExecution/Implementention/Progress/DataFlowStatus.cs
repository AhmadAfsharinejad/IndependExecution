using System.Collections.Generic;

namespace IndependExecution.Implementention.Progress
{
    //TODO staus is good name?
    public class DataFlowStatus
    {
        public List<NodeStatus> Nodes { get; }

        public List<LinkStatus> Links { get; }
        
        public DataFlowStatus()
        {
            Nodes = new List<NodeStatus>();
            Links = new List<LinkStatus>();
        }
    }
}
