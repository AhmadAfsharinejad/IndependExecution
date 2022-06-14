using IndependExecution.Dto;
using IndependExecution.Implementention.Progress;
using IndependExecution.Interfaces.Core;

namespace ETLEngine.Implementention.Core
{
    public class DataFlowMediator
    {
        private readonly IScenarioContainer _scenarioContainer;

        public void AddScenario(IScenario scenario)
        {
            _scenarioContainer.CreateDataFlow(scenario);
        }

        public DataFlowStatus GetScenario(IScenario scenario)
        {
           return _scenarioContainer.GetDataFlow(scenario).GetDataFlow();
        }

        public DataFlowMediator(IScenarioContainer scenarioContainer)
        {
            _scenarioContainer = scenarioContainer;
        }

        public void AddNode(IScenario scenario, AddNodeRequest addNodeRequest)
        {
            _scenarioContainer.GetDataFlow(scenario).AddNode(addNodeRequest);
        }

        public void AddLink(IScenario scenario, AddLinkRequest addLinkRequest)
        {
            _scenarioContainer.GetDataFlow(scenario).AddLink(addLinkRequest);
        }

        public void Run(IScenario scenario, RunRequest runRequest)
        {
            _scenarioContainer.GetDataFlow(scenario).Run(runRequest);
        }

        public IDataFlowPluginConfig GetConfig(IScenario scenario, string nodeId)
        {
            return _scenarioContainer.GetDataFlow(scenario).GetConfig(nodeId);
        }

        public void ChangeConfig(IScenario scenario, ChangeConfigRequest changeConfigRequest)
        {
            _scenarioContainer.GetDataFlow(scenario).ChangeConfig(changeConfigRequest);
        }
    }
}
