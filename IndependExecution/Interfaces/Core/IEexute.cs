using System;
using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface IEexute<TNode, TLink, TProgress>
        where TNode : INode
        where TLink : ILink<TNode>
    {
        IProgress<TProgress> Progress { get; }
        void RunAll();
        void CancelAll();
        void Run(IEnumerable<TNode> nodes);
        void Cancel(IEnumerable<TNode> nodes);
        void Invalid(IEnumerable<TNode> nodes);
        void Stop(IEnumerable<TNode> nodes);

        //Tabe haye dge chejori mishand?
        //melse gettable dataflow
    }
}
