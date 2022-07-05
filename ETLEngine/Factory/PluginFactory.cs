using System;
using System.Collections.Generic;
using ETLEngine.Plugin;
using IndependentExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;

namespace ETLEngine.Factory
{
    public class PluginFactory : IPluginFactory
    {
        public IPlugin GetPlugin(string pluginTypeId, string pluginId, IProgress<NodeStateChange> nodeProgress)
        {
            //TODO
            if (pluginTypeId == "DataTable")
                return new DataTablePlugin(pluginId,
                    new SocketForTest(new SampleMapping(new Dictionary<string, string>() { { "a", "Sample" } })),
                    nodeProgress);

            if(pluginTypeId == "SwitchPort")
                return new SwitchPortPlugin(pluginId,
                   new SocketForTest(new SampleMapping(new Dictionary<string, string>() { { "a", "Sample" } })),
                   nodeProgress);

            throw new NotSupportedException();

        }
    }
}
