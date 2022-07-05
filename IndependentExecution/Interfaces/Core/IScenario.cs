using IndependentExecution.Implementation.Progress;

namespace IndependentExecution.Interfaces.Core
{
    public interface IScenario :
        IExecutor,
        IScenarioConfigurable,
        IGraph
    {
        ScenarioStatus GetDataFlow();
    }
}
