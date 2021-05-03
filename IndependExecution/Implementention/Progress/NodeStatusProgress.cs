using System;

namespace IndependExecution.Implementention.Progress
{
    class NodeStatusProgress : Progress<NodeState>, IProgress<NodeState>
    {
        public void Report(NodeState value)
        {
            throw new NotImplementedException();
        }
    }
}
