using System;
using System.Collections.Generic;
using ETLEngine.Plugin;
using ETLEngine.Plugin.DataTable;
using ETLEngine.Plugin.SwitchPort;
using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace ETLEngine.Factory
{
    public class PluginFactory : IPluginFactory
    {
        public IPlugin GetPlugin(string pluginTypeId, IProgress<NodeStateChange> nodeProgress)
        {
            //TODO
            if (pluginTypeId == "DataTable")
                return new DataTablePlugin(Guid.NewGuid().ToString(),
                    new SocketForTest(new SampleMapping(new Dictionary<string, string> { { "a", "Sample" } })),
                    nodeProgress);

            if(pluginTypeId == "SwitchPort")
                return new SwitchPortPlugin(Guid.NewGuid().ToString(),
                   new SocketForTest(new SampleMapping(new Dictionary<string, string> { { "a", "Sample" } })),
                   nodeProgress);

            throw new NotSupportedException();

        }
    }
}
