using System.Collections.Generic;

namespace IndependExecution.Implementention.Progress
{
    public class DataFlowStatus
    {
        public List<NodeStatus> Nodes { get; }

        public DataFlowStatus()
        {
            this.Nodes = new List<NodeStatus>();
        }
    }
}
