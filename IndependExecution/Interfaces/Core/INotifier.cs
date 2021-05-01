namespace IndependExecution.Interfaces.Core
{
    public interface INotifier<T>
    {
        void Notify(T value);
    }
}
