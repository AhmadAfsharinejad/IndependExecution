using IndependExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Graph.Abstraction;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IPlugin : IPluginConfigurable, IPlugin<string, IBaseTable>
    {
        public string TypeId { get; }
        public string Location { get; set; }
        public string Note { get; set; }
    }
}
