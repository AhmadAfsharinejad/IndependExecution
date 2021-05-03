using Mohaymen.DataFlowExecutor.Core.Graph.Abstraction;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using System;

namespace IndependExecution.Interfaces.Core
{
    public interface IPluginFactory
    {
        IPlugin<string, IBaseTable> GetPlugin(string pluginTypeId, IProgress<NodeStateChange<string>> nodeProgress);
    }
}
