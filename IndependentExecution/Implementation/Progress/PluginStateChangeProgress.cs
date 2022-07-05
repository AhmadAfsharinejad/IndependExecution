using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using System;

namespace IndependentExecution.Implementation.Progress
{
    public class PluginStateChangeProgress : IProgress<NodeStateChange>
    {
        public event EventHandler<NodeStateChange>? ProgressChanged;

        public void Report(NodeStateChange value)
        {
            //this.OnReport(value);
            ProgressChanged?.Invoke(this, value);
        }
    }
}
