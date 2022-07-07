using System.Collections.Generic;
using IndependentExecution.Dto;
using IndependentExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Graph.Elements;

namespace IndependentExecution.Interfaces.Plugin
{
    //TODO interface niaze?
    public interface ILink : ILink<IBaseTable>
    {

    }

    public record Link : ILink
    {
        public INode<IBaseTable> Source { get; }

        public INode<IBaseTable> Target { get; }

        public IEnumerable<string> Filter { get; }

        public string Id { get; }

        public Link(LinkId id, IPlugin source, IPlugin target)
        {
            Id = id.ToString();
            Source = source;
            Target = target;
            Filter = new List<string>();
        }
    }
}
