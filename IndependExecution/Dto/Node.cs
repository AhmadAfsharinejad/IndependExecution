using IndependExecution.Interfaces.Core;

namespace IndependExecution.Dto
{
    public class Node : INode
    {
        public string Id { get; }

        public string TypeId { get; }

        public Node(string id, string typeId)
        {
            Id = id;
            TypeId = typeId;
        }
    }
}
