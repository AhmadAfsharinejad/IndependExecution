using System.Collections.Generic;
using IndependExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Graph.Elements;

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
            Id = id;
            Source = source;
            Target = target;
            Filter = new List<string>();
        }
    }
}
