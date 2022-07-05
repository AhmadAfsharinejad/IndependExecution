using IndependentExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Graph.Abstraction;

namespace IndependentExecution.Interfaces.Plugin
{
    public interface IPluginConfigurable : IPlugin<IBaseTable>
    {
        void ChangeConfig(IPluginConfig config);
        IPluginConfig GetConfig();
    }
}
