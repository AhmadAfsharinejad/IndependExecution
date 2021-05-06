using IndependExecution.Implementention.Progress;

namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlow :
        IExecute,
        IDataFlowConfigurable,
        IGraph
    {
        DataFlowStatus GetDataFlow();
    }
}
