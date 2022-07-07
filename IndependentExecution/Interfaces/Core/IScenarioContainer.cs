using IndependentExecution.Dto;
using IndependentExecution.Implementation.Core;

namespace IndependentExecution.Interfaces.Core
{
    public interface IScenarioContainer
    {
        Scenario GetScenario(ScenarioId scenarioId);
        void CreateScenario(ScenarioId scenarioId);
        void LoadScenario(ScenarioId scenarioId);
    }
}
