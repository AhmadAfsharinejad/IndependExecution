using System;
using System.Collections.Generic;
using System.Linq;
using IndependExecution.Dto;
using IndependExecution.Implementention.Progress;
using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Execution.Adaptor;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace IndependExecution.Implementention.Core
{
    public class DataFlow : IDataFlow
    {
        private readonly IProgress<DataFlowStatus> _progress;
        private readonly IDataFlowFacade<IBaseTable, IPlugin, ILink> _dataFlowFacade;
        private readonly IPluginFactory _pluginFactory;
        private readonly NodeStateChangeProgress _nodeProgress;
        private readonly DataFlowStatus _dataFlowStatus;

        public DataFlow(IProgress<DataFlowStatus> progress,
            IDataFlowFacade<IBaseTable, IPlugin, ILink> dataFlowFacade,
            IPluginFactory pluginExecutableFactory)
        {
            _progress = progress;
            _dataFlowFacade = dataFlowFacade;
            _pluginFactory = pluginExecutableFactory;
            _dataFlowStatus = new DataFlowStatus();
            _nodeProgress = new NodeStateChangeProgress();

            _nodeProgress.ProgressChanged += NodeProgress_ProgressChanged;
        }

        public void AddLink(AddLinkRequest addLinkRequest)
        {
            var linkId = GenerateLinkId();
            var link = new Link(linkId, _dataFlowFacade.GetNode(addLinkRequest.SourceId), _dataFlowFacade.GetNode(addLinkRequest.TargetId));/*, TODO fix maplinks*/
            _dataFlowFacade.AddLink(link);
            AddLinkStatuses(addLinkRequest, linkId);
            _progress.Report(_dataFlowStatus);
        }

        public void AddNode(AddNodeRequest addNodeRequest)
        {
            var plugin = _pluginFactory.GetPlugin(addNodeRequest.TypeId, _nodeProgress);
            plugin.Location = addNodeRequest.Location;
            _dataFlowFacade.AddNode(plugin);
            AddNodeToStatus(plugin);
            _progress.Report(_dataFlowStatus);
        }

        public void Cancel(IEnumerable<INode> nodes)
        {
            throw new NotImplementedException();
        }

        public void CancelAll()
        {
            throw new NotImplementedException();
        }

        public void ChangeConfig(ChangeConfigRequest changeConfigRequest)
        {
            var plugin = _dataFlowFacade.GetNode(changeConfigRequest.NodeId);
            plugin.ChangeConfig(changeConfigRequest.Config);

            //TODO check links
            EditNodeToStatus(plugin);
            _progress.Report(_dataFlowStatus);
        }

        public IDataFlowPluginConfig GetConfig(string nodeId)
        {
            var config = _dataFlowFacade.GetNode(nodeId).GetConfig();
            return new DataFlowPluginConfig
            {
                Config = config,
            };
        }

        public DataFlowStatus GetDataFlow()
        {
            return _dataFlowStatus;
        }

        public void Invalid(IEnumerable<INode> nodes)
        {
            throw new NotImplementedException();
        }

        public void Load(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveLink(ILink link)
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(INode node)
        {
            throw new NotImplementedException();
        }

        public void Run(RunRequest runRequest)
        {
            foreach (var nodeId in runRequest.NodeIds)
            {
                //TODO run list id begire
                _dataFlowFacade.Run(nodeId);
            }
        }

        public void RunAll()
        {

        }

        public void Stop(IEnumerable<INode> nodes)
        {
            throw new NotImplementedException();
        }

        private void NodeProgress_ProgressChanged(object sender, NodeStateChange e)
        {
            _dataFlowStatus.Nodes.First(x => x.Id == e.NodeId).State = e.After.ToString();
            _progress.Report(_dataFlowStatus);
        }

        private void AddNodeToStatus(IPlugin plugin)
        {
            _dataFlowStatus.Nodes.Add(new NodeStatus(plugin.Id, plugin.TypeId)
            {
                State = "Idle",
                Location = plugin.Location,
                InputPorts = plugin.Inputs,
                OutputPorts = plugin.Outputs,
            });
        }

        private void EditNodeToStatus(IPlugin plugin)
        {
            var node = _dataFlowStatus.Nodes.First(x => x.Id == plugin.Id);

            node.InputPorts = plugin.Inputs;
            node.OutputPorts = plugin.Outputs;
        }

        private void AddLinkStatuses(AddLinkRequest addLinkRequest, string linkId)
        {
            _dataFlowStatus.Links.Add(new LinkStatus(linkId,
                addLinkRequest.SourceId,
                addLinkRequest.TargetId,
                addLinkRequest.SourceMapLink,
                addLinkRequest.TargetMapLink));
        }

        private string GenerateLinkId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
