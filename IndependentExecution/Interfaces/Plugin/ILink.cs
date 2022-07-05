using System.Collections.Generic;
using IndependentExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Graph.Elements;

namespace IndependentExecution.Interfaces.Plugin
{
    public interface ILink : ILink<IBaseTable>
    {

    }

    public record Link : ILink
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
            this.Filter = new List<string>();
        }
    }
}
