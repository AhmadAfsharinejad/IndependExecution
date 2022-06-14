using System;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IPluginFactory
    {
        IPlugin GetPlugin(string pluginTypeId, IProgress<NodeStateChange> nodeProgress);
    }
}
