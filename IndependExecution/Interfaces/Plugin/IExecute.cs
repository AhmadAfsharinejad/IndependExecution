using System.Collections.Generic;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IExecute
    {
        //return?
        void Run(IEnumerable<object> inputTables);
        void Cancel();
        void Dispose();

        //Tabe haye dge chejori mishand?
        //melse gettable dataflow
    }
}
