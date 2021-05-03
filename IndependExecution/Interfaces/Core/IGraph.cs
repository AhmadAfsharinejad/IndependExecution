using IndependExecution.Dto;

namespace IndependExecution.Interfaces.Core
{
    public interface IGraph
    {
        void AddNode(AddNodeRequest addNodeRequest);
        void AddLink(INode source, INode target, IMapLink maplink);
        void RemoveNode(INode node);
        void RemoveLink(ILink link);
    }
}
