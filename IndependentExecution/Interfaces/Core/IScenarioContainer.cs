using IndependentExecution.Implementation.Core;

namespace IndependentExecution.Interfaces.Core
{
    public interface IScenarioContainer
    {
        Scenario GetScenario(string scenarioId);
        void CreateScenario(string scenarioId);
        void LoadScenario(string scenarioId);
    }
}
