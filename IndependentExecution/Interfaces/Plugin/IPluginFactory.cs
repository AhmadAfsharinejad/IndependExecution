using System;
using IndependentExecution.Dto;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace IndependentExecution.Interfaces.Plugin
{
    public interface IPluginFactory
    {
        IPlugin GetPlugin(PluginTypeId pluginTypeId, PluginId pluginId, IProgress<NodeStateChange> nodeProgress);
    }
}
