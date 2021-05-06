using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using System.Collections.Generic;

namespace IndependExecution.Implementention.Core
{
    public class DataFlowPluginConfig : IDataFlowPluginConfig
    {
        public IPluginConfig Config { get; set; }

        public List<ITable> InputTables { get; set; }
    }
}
