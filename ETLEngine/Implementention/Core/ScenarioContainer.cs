using System;
using System.Collections.Generic;
using ETLEngine.Factory;
using IndependentExecution.Implementation.Core;
using IndependentExecution.Implementation.Progress;
using IndependentExecution.Interfaces.Core;
using IndependentExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Execution.Adaptor;

namespace ETLEngine.Implementention.Core
{
    public class ScenarioContainer : IScenarioContainer
    {
        private readonly ScenarioProgress _scenarioProgress;
        private readonly Dictionary<string, Scenario> _dataFlows;

        public ScenarioContainer(ScenarioProgress scenarioProgress)
        {
            this._dataFlows = new Dictionary<string, Scenario>();
            this._scenarioProgress = scenarioProgress;
        }

        public void CreateScenario(string scenarioId)
        {
            if (_dataFlows.TryGetValue(scenarioId, out var _))
                throw new Exception();

            var pluginFactory = new PluginFactory();
            var scenarioFacade = new DataFlowFacade<IBaseTable, IPlugin, ILink>();
            var dataFlow = new Scenario(_scenarioProgress, scenarioFacade, pluginFactory);
            _dataFlows[scenarioId] = dataFlow;
        }

        public Scenario GetScenario(string scenarioId)
        {
            if (_dataFlows.TryGetValue(scenarioId, out var dataFlow))
                return dataFlow;

            throw new Exception();
        }
    }
}
