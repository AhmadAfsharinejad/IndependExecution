using IndependExecution.Interfaces.Core;
using IndependExecution.Progress;
using System;
using System.Collections.Generic;

namespace IndependExecution.Implementention.Core
{
    public class DataFlow : IDataFlow
    {
        private readonly DataFlowProgress progress;

        public DataFlow(DataFlowProgress progress)
        {
            this.progress = progress;
        }

        public void AddLink(INode source, INode target, IMapLink maplink)
        {
            throw new NotImplementedException();
        }

        public void AddNode(INode node)
        {
            throw new NotImplementedException();
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

        public void Run(IEnumerable<INode> nodes)
        {
            throw new NotImplementedException();
        }

        public void RunAll()
        {
            throw new NotImplementedException();
        }

        public void Stop(IEnumerable<INode> nodes)
        {
            throw new NotImplementedException();
        }

    }
}
