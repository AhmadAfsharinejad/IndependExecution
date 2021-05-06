using IndependExecution.Interfaces.Plugin;

namespace IndependExecution.Interfaces.Core
{
    public interface IPluginContainer
    {
        void AddPlugin(IPlugin plugin);

        IPlugin GetPlugin(string id);
    }
}
