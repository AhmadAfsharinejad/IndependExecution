namespace IndependExecution.Interfaces.Core
{
    public interface IConfig<TNotify>
    {
        INotifier<TNotify> Notifier { get; }
        void ChangeConfig<TConfig>(INode node, TConfig config);
        TConfig GetConfig<TConfig>(INode node);
    }
}
