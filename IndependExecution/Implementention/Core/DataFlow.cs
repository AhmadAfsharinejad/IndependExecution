using IndependExecution.Dto;
using IndependExecution.Implementention.Progress;
using IndependExecution.Interfaces.Core;
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
        private readonly IDataFlowFacade<string, IBaseTable, string> dataFlowFacade;
        private readonly IPluginFactory pluginFactory;
        private readonly Progress<NodeStateChange<string>> nodeProgress;
        private readonly DataFlowStatus DataFlowStatus;

        public DataFlow(IProgress<DataFlowStatus> progress,
            IDataFlowFacade<string, IBaseTable, string> dataFlowFacade,
            IPluginFactory pluginExecutableFactory)
        {
            this.progress = progress;
            this.dataFlowFacade = dataFlowFacade;
            this.pluginFactory = pluginExecutableFactory;
            this.DataFlowStatus = new DataFlowStatus();
            this.nodeProgress = new Progress<NodeStateChange<string>>();

            this.nodeProgress.ProgressChanged += NodeProgress_ProgressChanged1;
        }

        public void AddLink(INode source, INode target, IMapLink maplink)
        {
            throw new NotImplementedException();
        }

        public void AddNode(AddNodeRequest addNodeRequest)
        {
            var plugin = pluginFactory.GetPlugin(addNodeRequest.TypeId, nodeProgress);
            dataFlowFacade.AddNode(plugin);
            AddNodeToStatus(addNodeRequest, plugin.Id);
            progress.Report(DataFlowStatus);
        }

        public void Cancel(IEnumerable<INode> nodes)
        {
            throw new NotImplementedException();
        }

        public void CancelAll()
        {
            throw new NotImplementedException();
        }

        public void ChangeConfig<TConfig>(INode node, TConfig config)
        {
            throw new NotImplementedException();
        }

        public IPluginConfig<TConfig> GetConfig<TConfig>(INode node)
        {
            throw new NotImplementedException();
        }

        public object GetDataFlow()
        {
            throw new NotImplementedException();
        }

        public List<IMapLink> GetMaps(INode node)
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

        private void NodeProgress_ProgressChanged1(object sender, NodeStateChange<string> e)
        {
            DataFlowStatus.Nodes.First(x => x.Id == e.NodeId).State = e.After.ToString();
            progress.Report(DataFlowStatus);
        }

        private void AddNodeToStatus(AddNodeRequest addNodeRequest, string id)
        {
            DataFlowStatus.Nodes.Add(new NodeStatus(id, addNodeRequest.TypeId)
            {
                State = "Idle",
                Location = addNodeRequest.Location,
            });
        }
    }
}
