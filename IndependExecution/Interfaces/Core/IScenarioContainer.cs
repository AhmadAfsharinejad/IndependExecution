using IndependExecution.Interfaces.Core;

namespace IndependExecution.Implementention.Core
{
    public interface IScenarioContainer
    {
        DataFlow GetDataFlow(IScenario scenario);
        void CreateDataFlow(IScenario scenario);
    }
}
