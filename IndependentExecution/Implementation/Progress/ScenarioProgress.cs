using System;

namespace IndependentExecution.Implementation.Progress
{
    //public class DataFlowProgress : Progress<DataFlowStatus>, IProgress<DataFlowStatus>
    public class ScenarioProgress : IProgress<ScenarioStatus>
    {
        public event EventHandler<ScenarioStatus>? ProgressChanged;

        public void Report(ScenarioStatus value)
        {
            //this.OnReport(value);
            ProgressChanged?.Invoke(this, value);
        }
    }
}
