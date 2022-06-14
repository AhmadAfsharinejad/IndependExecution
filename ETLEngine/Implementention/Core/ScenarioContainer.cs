﻿using System;
using System.Collections.Generic;
using ETLEngine.Factory;
using IndependExecution.Implementention.Core;
using IndependExecution.Implementention.Progress;
using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Execution.Adaptor;

namespace ETLEngine.Implementention.Core
{
    public class ScenarioContainer : IScenarioContainer
    {
        private readonly DataFlowProgress _dataFlowProgress;
        private readonly Dictionary<string, DataFlow> _dataFlows;

        public ScenarioContainer(DataFlowProgress dataFlowProgress)
        {
            _dataFlows = new Dictionary<string, DataFlow>();
            _dataFlowProgress = dataFlowProgress;
        }

        public void CreateDataFlow(IScenario scenario)
        {
            if (_dataFlows.TryGetValue(scenario.Id, out var _))
                throw new Exception();

            var pluginFactory = new PluginFactory();
            var dataFlowFacade = new DataFlowFacade<IBaseTable, IPlugin, ILink>();
            var dataFlow = new DataFlow(_dataFlowProgress, dataFlowFacade, pluginFactory);
            _dataFlows[scenario.Id] = dataFlow;
        }

        public DataFlow GetDataFlow(IScenario scenario)
        {
            if (_dataFlows.TryGetValue(scenario.Id, out var dataFlow))
                return dataFlow;

            throw new Exception();
        }
    }
}
