using IndependExecution.Implementention.Progress;
using System;

namespace IndependExecution.Progress
{
    public class DataFlowProgress : Progress<DataFlowStatus>, IProgress<DataFlowStatus>
    {
        public void Report(DataFlowStatus value)
        {
            this.OnReport(value);
        }
    }
}
