using ETLEngine.Plugin;
using IndependExecution.Interfaces.Core;
using IndependExecution.Sample.Plugin;
using Mohaymen.DataFlowExecutor.Core.Graph.Abstraction;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using System;
using System.Collections.Generic;

namespace IndependExecution.Sample.Factory
{
    public class PluginFactory : IPluginFactory
    {
        public IPlugin<string, IBaseTable> GetPlugin(string pluginTypeId, IProgress<NodeStateChange<string>> nodeProgress)
        {
            return new DataTablePlugin(Guid.NewGuid().ToString(),
                new SocketForTest(new SampleMapping(new Dictionary<string, string>() { { "a", "Sample" } })),
                nodeProgress);
        }
    }
}
