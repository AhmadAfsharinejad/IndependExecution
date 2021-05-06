using ETLEngine.Implementention.Core;
using IndependExecution.Interfaces.Core;
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
            var dataFlowFacade = new DataFlowFacade<string, IBaseTable, string>();
            var pluginContainer = new PluginContainer();
            var dataFlow = new DataFlow(dataFlowProgress, dataFlowFacade, pluginFactory, pluginContainer);
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
