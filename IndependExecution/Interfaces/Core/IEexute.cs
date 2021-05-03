using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface IEexute
    {
        void RunAll();
        void CancelAll();
        void Run(IEnumerable<INode> nodes);
        void Cancel(IEnumerable<INode> nodes);
        void Invalid(IEnumerable<INode> nodes);
        void Stop(IEnumerable<INode> nodes);

        //Tabe haye dge chejori mishand?
        //melse gettable dataflow
    }
}
