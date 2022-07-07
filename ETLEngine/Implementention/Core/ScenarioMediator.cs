using IndependentExecution.Dto;
using IndependentExecution.Interfaces.Core;

namespace ETLEngine.Implementention.Core
{
    public class ScenarioMediator
    {
        private readonly IScenarioContainer _scenarioContainer;

        public void AddScenario(ScenarioId scenarioId)
        {
            _scenarioContainer.CreateScenario(scenarioId);
        }

        public ScenarioStatus LoadScenario(ScenarioId scenarioId)
        {
           return _scenarioContainer.GetScenario(scenarioId).GetScenarioStatus();
        }

        public ScenarioMediator(IScenarioContainer scenarioContainer)
        {
            _scenarioContainer = scenarioContainer;
        }

        public void AddPlugin(ScenarioId scenarioId, AddPluginRequest addPluginRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).AddPlugin(addPluginRequest);
        }

        public void AddLink(ScenarioId scenarioId, AddLinkRequest addLinkRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).AddLink(addLinkRequest);
        }

        public void Run(ScenarioId scenarioId, RunRequest runRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).Run(runRequest);
        }

        public IScenarioPluginConfig GetConfig(ScenarioId scenarioId, PluginId pluginId)
        {
            return _scenarioContainer.GetScenario(scenarioId).GetConfig(pluginId);
        }

        public void ChangeConfig(ScenarioId scenarioId, ChangeConfigRequest changeConfigRequest)
        {
            _scenarioContainer.GetScenario(scenarioId).ChangeConfig(changeConfigRequest);
        }
    }
}
