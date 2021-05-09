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
        private readonly Progress<NodeStateChange> nodeProgress;
        private readonly DataFlowStatus dataFlowStatus;
        private readonly IPluginContainer pluginContainer;

        public DataFlow(IProgress<DataFlowStatus> progress,
            IDataFlowFacade<IBaseTable, IPlugin, ILink> dataFlowFacade,
            IPluginFactory pluginExecutableFactory,
            IPluginContainer pluginContainer)
        {
            this.progress = progress;
            this.dataFlowFacade = dataFlowFacade;
            this.pluginFactory = pluginExecutableFactory;
            this.dataFlowStatus = new DataFlowStatus();
            this.nodeProgress = new Progress<NodeStateChange>();

            this.nodeProgress.ProgressChanged += NodeProgress_ProgressChanged;
            this.pluginContainer = pluginContainer;
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
            pluginContainer.AddPlugin(plugin);
            AddNodeToStatus(plugin, plugin.Id);
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
            dataFlowFacade.GetNode(changeConfigRequest.nodeId).ChangeConfig(changeConfigRequest.config);
        }

        public IDataFlowPluginConfig GetConfig(string nodeId)
        {
            var config = pluginContainer.GetPlugin(nodeId).GetConfig();
            return new DataFlowPluginConfig()
            {
                Config = config,
            };
        }

        public DataFlowStatus GetDataFlow()
        {
            return dataFlowStatus;
        }

        public List<IMapLink> GetMaps(string nodeId)
        {
            throw new NotImplementedException();
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

        private void AddNodeToStatus(IPlugin plugin, string id)
        {
            dataFlowStatus.Nodes.Add(new NodeStatus(id, plugin.TypeId)
            {
                State = "Idle",
                Location = plugin.Location,
            });
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
