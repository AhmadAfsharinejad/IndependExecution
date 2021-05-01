using IndependExecution.Interfaces.Core;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IViewModel<IOutputChangeNotifier> :
        IExecute,
        IConfig<IOutputChangeNotifier>,
        INode
    {

    }
}
