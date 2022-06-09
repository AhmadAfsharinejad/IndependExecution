using System;
using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace IndependExecution.Interfaces.Core
{
    public interface IPluginFactory
    {
        IPlugin GetPlugin(string pluginTypeId, IProgress<NodeStateChange> nodeProgress);
    }
}
