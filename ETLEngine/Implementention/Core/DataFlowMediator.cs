using IndependExecution.Dto;
using IndependExecution.Implementention.Progress;
using IndependExecution.Interfaces.Core;

namespace IndependExecution.Implementention.Core
{
    public class DataFlowMediator
    {
        private readonly IScenarioContainer scenarioContainer;

        public void AddScenario(IScenario scenario)
        {
            scenarioContainer.CreateDataFlow(scenario);
        }

        public DataFlowStatus GetScenario(IScenario scenario)
        {
           return scenarioContainer.GetDataFlow(scenario).GetDataFlow();
        }

        public DataFlowMediator(IScenarioContainer scenarioContainer)
        {
            this.scenarioContainer = scenarioContainer;
        }

        public void AddNode(IScenario scenario, AddNodeRequest addNodeRequest)
        {
            scenarioContainer.GetDataFlow(scenario).AddNode(addNodeRequest);
        }

        public void AddLink(IScenario scenario, AddLinkRequest addLinkRequest)
        {
            scenarioContainer.GetDataFlow(scenario).AddLink(addLinkRequest);
        }

        public void Run(IScenario scenario, RunRequest runRequest)
        {
            scenarioContainer.GetDataFlow(scenario).Run(runRequest);
        }

        public IDataFlowPluginConfig GetConfig(IScenario scenario, string nodeId)
        {
            return scenarioContainer.GetDataFlow(scenario).GetConfig(nodeId);
        }

        public void ChangeConfig(IScenario scenario, ChangeConfigRequest changeConfigRequest)
        {
            scenarioContainer.GetDataFlow(scenario).ChangeConfig(changeConfigRequest);
        }
    }
}
