namespace IndependExecution.Interfaces.Core
{
    public interface IGraph<TNotify>
    {
        INotifier<TNotify> Notifier { get; }
        void AddNode(INode node);
        void AddLink(ILink link);
        void RemoveNode(INode node);
        void RemoveLink(ILink link);
    }
}
