using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using IndependExecution.Progress;
using IndependExecution.Sample.Factory;
using Mohaymen.DataFlowExecutor.Core.Execution.Adaptor;
using System;
using System.Collections.Generic;

namespace IndependExecution.Implementention.Core
{
    public class ScenarioContainer : IScenarioContainer
    {
        private readonly DataFlowProgress dataFlowProgress;
        private readonly Dictionary<string, DataFlow> dataFlows;

        public ScenarioContainer(DataFlowProgress dataFlowProgress)
        {
            this.dataFlows = new Dictionary<string, DataFlow>();
            this.dataFlowProgress = dataFlowProgress;
        }

        public void CreateDataFlow(IScenario scenario)
        {
            if (dataFlows.TryGetValue(scenario.Id, out var _))
                throw new Exception();

            var pluginFactory = new PluginFactory();
            var dataFlowFacade = new DataFlowFacade<IBaseTable, IPlugin, ILink>();
            var dataFlow = new DataFlow(dataFlowProgress, dataFlowFacade, pluginFactory);
            dataFlows[scenario.Id] = dataFlow;
        }

        public DataFlow GetDataFlow(IScenario scenario)
        {
            if (dataFlows.TryGetValue(scenario.Id, out var dataFlow))
                return dataFlow;

            throw new Exception();
        }
    }
}
