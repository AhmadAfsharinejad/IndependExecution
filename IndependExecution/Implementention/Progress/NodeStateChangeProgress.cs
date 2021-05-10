using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using System;

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
