using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using System;

namespace IndependExecution.Interfaces.Core
{
    public interface IPluginFactory
    {
        IPlugin GetPlugin(string pluginTypeId, IProgress<NodeStateChange<string>> nodeProgress);
    }
}
