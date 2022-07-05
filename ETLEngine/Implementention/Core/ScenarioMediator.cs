using IndependentExecution.Dto;
using IndependentExecution.Implementation.Progress;
using IndependentExecution.Interfaces.Core;

namespace ETLEngine.Implementention.Core
{
    public class ScenarioMediator
    {
        private readonly IScenarioContainer _scenarioContainer;

        public void AddScenario(string scenarioId)
        {
            _scenarioContainer.CreateScenario(scenarioId);
        }

        public ScenarioStatus GetScenario(string scenarioId)
        {
           return _scenarioContainer.GetScenario(scenarioId).GetDataFlow();
        }

        public ScenarioMediator(IScenarioContainer scenarioContainer)
        {
            this._scenarioContainer = scenarioContainer;
        }

        public void AddPlugin(string scenarioId, AddPluginRequest addPluginRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).AddPlugin(addPluginRequest);
        }

        public void AddLink(string scenarioId, AddLinkRequest addLinkRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).AddLink(addLinkRequest);
        }

        public void Run(string scenarioId, RunRequest runRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).Run(runRequest);
        }

        public IScenarioPluginConfig GetConfig(string scenarioId, string nodeId)
        {
            return _scenarioContainer.GetScenario(scenarioId).GetConfig(nodeId);
        }

        public void ChangeConfig(string scenarioId, ChangeConfigRequest changeConfigRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).ChangeConfig(changeConfigRequest);
        }
    }
}
