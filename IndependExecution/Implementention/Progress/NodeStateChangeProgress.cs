using System;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace IndependExecution.Implementention.Progress
{
    public class NodeStateChangeProgress : IProgress<NodeStateChange>
    {
        public event EventHandler<NodeStateChange>? ProgressChanged;

        public void Report(NodeStateChange value)
        {
            //this.OnReport(value);
            ProgressChanged?.Invoke(this, value);
        }
    }
}
