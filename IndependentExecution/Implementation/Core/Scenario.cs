using System;
using System.Collections.Generic;
using System.Linq;
using IndependentExecution.Dto;
using IndependentExecution.Implementation.Progress;
using IndependentExecution.Interfaces.Core;
using IndependentExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Execution.Adaptor;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace IndependentExecution.Implementation.Core
{
    public class Scenario : IScenario
    {
        private readonly IProgress<ScenarioStatus> _progress;
        private readonly IDataFlowFacade<IBaseTable, IPlugin, ILink> _dataFlowFacade;
        private readonly IPluginFactory _pluginFactory;
        private readonly PluginStateChangeProgress _pluginProgress;
        private readonly ScenarioStatus _scenarioStatus;

        public Scenario(IProgress<ScenarioStatus> progress,
            IDataFlowFacade<IBaseTable, IPlugin, ILink> dataFlowFacade,
            IPluginFactory pluginExecutableFactory)
        {
            _progress = progress;
            _dataFlowFacade = dataFlowFacade;
            _pluginFactory = pluginExecutableFactory;
            _scenarioStatus = new ScenarioStatus();
            _pluginProgress = new PluginStateChangeProgress();

            _pluginProgress.ProgressChanged += PluginProgress_ProgressChanged;
        }

        public void AddLink(AddLinkRequest addLinkRequest)
        {
            var linkId = GenerateLinkId();
            var link = new Link(linkId, _dataFlowFacade.GetNode(addLinkRequest.SourceId), _dataFlowFacade.GetNode(addLinkRequest.TargetId));/*, TODO fix maplinks*/
            _dataFlowFacade.AddLink(link);
            AddLinkStatuses(addLinkRequest, linkId);
            _progress.Report(_scenarioStatus);
        }

        public PluginStatus AddPlugin(AddPluginRequest addPluginRequest)
        {
            var plugin = _pluginFactory.GetPlugin(addPluginRequest.TypeId, addPluginRequest.Id, _pluginProgress);
            plugin.Location = addPluginRequest.Location;
            _dataFlowFacade.AddNode(plugin);
            AddPluginToStatus(plugin);
            _progress.Report(_scenarioStatus);

            return new PluginStatus(plugin.Id) 
            {
                State = plugin.State.ToString(),
                InputPorts = plugin.Inputs,
                OutputPorts = plugin.Outputs,
            };
        }

        public void Cancel(IList<string> pluginIds)
        {
            throw new NotImplementedException();
        }

        public void CancelAll()
        {
            throw new NotImplementedException();
        }

        public void ChangeConfig(ChangeConfigRequest changeConfigRequest)
        {
            var plugin = _dataFlowFacade.GetNode(changeConfigRequest.PluginId);
            plugin.ChangeConfig(changeConfigRequest.Config);

            //TODO check links
            EditPluginToStatus(plugin);
            _progress.Report(_scenarioStatus);
        }

        public IScenarioPluginConfig GetConfig(string pluginId)
        {
            var config = _dataFlowFacade.GetNode(pluginId).GetConfig();
            return new ScenarioPluginConfig
            {
                Config = config,
            };
        }

        public void Invalid(IList<string> pluginIds)
        {
            throw new NotImplementedException();
        }

        public ScenarioStatus GetScenarioStatus()
        {
            throw new NotImplementedException();
        }
        
        public ScenarioStatus Load()
        {
            throw new NotImplementedException();
        }

        public void RemoveLink(ILink link)
        {
            throw new NotImplementedException();
        }

        public void MovePlugins(IList<MovePluginRequest> plugins)
        {
            throw new NotImplementedException();
        }

        public void RemovePlugin(string pluginId)
        {
            throw new NotImplementedException();
        }

        public void Run(RunRequest runRequest)
        {
            foreach (var pluginId in runRequest.PluginIds)
            {
                //TODO run list id begire
                _dataFlowFacade.Run(pluginId);
            }
        }

        public void ChangeProcessor(string processorId)
        {
            throw new NotImplementedException();
        }

        public void ChangeExecutor(string executorId)
        {
            throw new NotImplementedException();
        }

        public RunTimeParametersResponse GetRunTimeParameters(RunRequest runRequest)
        {
            throw new NotImplementedException();
        }
        public void RunAll()
        {

        }

        public void Stop(IList<string> pluginIds)
        {
            throw new NotImplementedException();
        }

        public IList<IBaseTable> GetResult(string pluginId)
        {
            //TODO
            throw new NotImplementedException();
        }

        private void PluginProgress_ProgressChanged(object? sender, NodeStateChange e)
        {
            _scenarioStatus.Plugins.First(x => x.Id == e.NodeId).State = e.After.ToString();
            _progress.Report(_scenarioStatus);
        }

        private void AddPluginToStatus(IPlugin plugin)
        {
            _scenarioStatus.Plugins.Add(new PluginStatus(plugin.Id)
            {
                State = "Idle",
                InputPorts = plugin.Inputs,
                OutputPorts = plugin.Outputs,
            });
        }

        private void EditPluginToStatus(IPlugin plugin)
        {
            var pluginStatus = _scenarioStatus.Plugins.First(x => x.Id == plugin.Id);

            pluginStatus.InputPorts = plugin.Inputs;
            pluginStatus.OutputPorts = plugin.Outputs;
        }

        private void AddLinkStatuses(AddLinkRequest addLinkRequest, string linkId)
        {
            _scenarioStatus.Links.Add(new LinkStatus
            {
                SourceId = addLinkRequest.SourceId,
                TargetId = addLinkRequest.TargetId,
                SourcePortId = addLinkRequest.SourcePortId,
                TargetPortId = addLinkRequest.TargetPortId
            });
        }

        private string GenerateLinkId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
