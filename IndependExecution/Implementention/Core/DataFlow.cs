using IndependExecution.Dto;
using IndependExecution.Implementention.Progress;
using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Execution.Adaptor;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndependExecution.Implementention.Core
{
    public class DataFlow : IDataFlow
    {
        private readonly IProgress<DataFlowStatus> progress;
        private readonly IDataFlowFacade<IBaseTable, IPlugin, ILink> dataFlowFacade;
        private readonly IPluginFactory pluginFactory;
        private readonly NodeStateChangeProgress nodeProgress;
        private readonly DataFlowStatus dataFlowStatus;

        public DataFlow(IProgress<DataFlowStatus> progress,
            IDataFlowFacade<IBaseTable, IPlugin, ILink> dataFlowFacade,
            IPluginFactory pluginExecutableFactory)
        {
            this.progress = progress;
            this.dataFlowFacade = dataFlowFacade;
            this.pluginFactory = pluginExecutableFactory;
            this.dataFlowStatus = new DataFlowStatus();
            this.nodeProgress = new NodeStateChangeProgress();

            this.nodeProgress.ProgressChanged += NodeProgress_ProgressChanged;
        }

        public void AddLink(AddLinkRequest addLinkRequest)
        {
            var linkId = GenerateLinkId();
            var link = new Link(linkId, dataFlowFacade.GetNode(addLinkRequest.SourceId), dataFlowFacade.GetNode(addLinkRequest.TargetId));/*, TODO fix maplinks*/
            dataFlowFacade.AddLink(link);
            AddLinkStatuses(addLinkRequest, linkId);
            progress.Report(dataFlowStatus);
        }

        public void AddNode(AddNodeRequest addNodeRequest)
        {
            var plugin = pluginFactory.GetPlugin(addNodeRequest.TypeId, nodeProgress);
            plugin.Location = addNodeRequest.Location;
            dataFlowFacade.AddNode(plugin);
            AddNodeToStatus(plugin);
            progress.Report(dataFlowStatus);
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
            var plugin = dataFlowFacade.GetNode(changeConfigRequest.nodeId);
            plugin.ChangeConfig(changeConfigRequest.config);

            //TODO check links
            EditNodeToStatus(plugin);
            progress.Report(dataFlowStatus);
        }

        public IDataFlowPluginConfig GetConfig(string nodeId)
        {
            var config = dataFlowFacade.GetNode(nodeId).GetConfig();
            return new DataFlowPluginConfig()
            {
                Config = config,
            };
        }

        public DataFlowStatus GetDataFlow()
        {
            return dataFlowStatus;
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
                dataFlowFacade.Run(nodeId);
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
            dataFlowStatus.Nodes.First(x => x.Id == e.NodeId).State = e.After.ToString();
            progress.Report(dataFlowStatus);
        }

        private void AddNodeToStatus(IPlugin plugin)
        {
            dataFlowStatus.Nodes.Add(new NodeStatus(plugin.Id, plugin.TypeId)
            {
                State = "Idle",
                Location = plugin.Location,
                InputPorts = plugin.Inputs,
                OutputPorts = plugin.Outputs,
            });
        }

        private void EditNodeToStatus(IPlugin plugin)
        {
            var node = dataFlowStatus.Nodes.First(x => x.Id == plugin.Id);

            node.InputPorts = plugin.Inputs;
            node.OutputPorts = plugin.Outputs;
        }

        private void AddLinkStatuses(AddLinkRequest addLinkRequest, string linkId)
        {
            dataFlowStatus.Links.Add(new LinkStatus(linkId,
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
