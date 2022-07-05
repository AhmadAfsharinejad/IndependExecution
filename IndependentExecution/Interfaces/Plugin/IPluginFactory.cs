using System;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace IndependentExecution.Interfaces.Plugin
{
    public interface IPluginFactory
    {
        IPlugin GetPlugin(string pluginTypeId, string pluginId, IProgress<NodeStateChange> nodeProgress);
    }
}
