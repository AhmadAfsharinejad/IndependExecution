using IndependExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Graph.Abstraction;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IPluginConfigurable : IPlugin<string, IBaseTable>
    {
        void ChangeConfig(IPluginConfig config);
        IPluginConfig GetConfig();
    }
}
