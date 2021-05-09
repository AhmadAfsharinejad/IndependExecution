using IndependExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Graph.Elements;
using System.Collections.Generic;

namespace IndependExecution.Interfaces.Plugin
{
    public interface ILink : ILink<IBaseTable>
    {

    }

    public class Link : ILink
    {
        public INode<IBaseTable> Source { get; }

        public INode<IBaseTable> Target { get; }

        public IEnumerable<string> Filter { get; }

        public string Id { get; }

        public Link(string id, IPlugin source, IPlugin target)
        {
            this.Id = id;
            this.Source = source;
            this.Target = target;
        }
    }
}
