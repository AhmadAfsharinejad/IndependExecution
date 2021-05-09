using ETLEngine.Plugin;
using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using IndependExecution.Sample.Plugin;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using System;
using System.Collections.Generic;

namespace IndependExecution.Sample.Factory
{
    public class PluginFactory : IPluginFactory
    {
        public IPlugin GetPlugin(string pluginTypeId, IProgress<NodeStateChange> nodeProgress)
        {
            //TODO
            if (pluginTypeId == "DataTable")
                return new DataTablePlugin(Guid.NewGuid().ToString(),
                    new SocketForTest(new SampleMapping(new Dictionary<string, string>() { { "a", "Sample" } })),
                    nodeProgress);

            if(pluginTypeId == "SwitchPort")
                return new SwitchPortPlugin(Guid.NewGuid().ToString(),
                   new SocketForTest(new SampleMapping(new Dictionary<string, string>() { { "a", "Sample" } })),
                   nodeProgress);

            throw new NotSupportedException();

        }
    }
}
