namespace IndependExecution.Interfaces.Core
{
    public interface IGraph<TNode, TLink, TNotify>
        where TNode : INode
        where TLink : ILink<TNode>
    {
        INotifier<TNotify> Notifier { get; }
        void AddNode(TNode node);
        void AddLink(TLink link);
        void RemoveNode(TNode node);
        void RemoveLink(TLink link);
    }
}
