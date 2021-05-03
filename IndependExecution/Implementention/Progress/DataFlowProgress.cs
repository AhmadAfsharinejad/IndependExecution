using System;

namespace IndependExecution.Progress
{
    public class DataFlowProgress : IProgress<int>
    {
        public void Report(int value)
        {
            throw new NotImplementedException();
        }
    }
}
