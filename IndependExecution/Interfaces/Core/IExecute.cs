using IndependExecution.Dto;
using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface IExecute
    {
        void RunAll();
        void CancelAll();
        void Run(RunRequest runRequest);
        void Cancel(IEnumerable<INode> nodes);
        void Invalid(IEnumerable<INode> nodes);
        void Stop(IEnumerable<INode> nodes);

        //Tabe haye dge chejori mishand?
        //melse gettable dataflow
    }
}
