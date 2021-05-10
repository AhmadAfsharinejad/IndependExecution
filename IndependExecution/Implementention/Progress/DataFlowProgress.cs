using IndependExecution.Implementention.Progress;
using System;

namespace IndependExecution.Progress
{
    //public class DataFlowProgress : Progress<DataFlowStatus>, IProgress<DataFlowStatus>
    public class DataFlowProgress : IProgress<DataFlowStatus>
    {
        public event EventHandler<DataFlowStatus>? ProgressChanged;

        public void Report(DataFlowStatus value)
        {
            //this.OnReport(value);
            ProgressChanged?.Invoke(this, value);
        }
    }
}
