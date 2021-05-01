namespace IndependExecution.Interfaces.Core
{
    public interface IConfig<TNode, TNotify>
        where TNode : INode
    {
        INotifier<TNotify> Notifier { get; }
        void ChangeConfig<TConfig>(TNode node, TConfig config);
        TConfig GetConfig<TConfig>(TNode node);
    }
}
