namespace IndependExecution.Interfaces.Plugin
{
    public interface IOutputChangeNotifier<T>
    {
        void Notify(T value);
    }
}
