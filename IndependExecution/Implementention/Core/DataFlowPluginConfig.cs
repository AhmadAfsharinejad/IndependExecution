using System.Collections.Generic;
using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;

namespace IndependExecution.Implementention.Core
{
    public class DataFlowPluginConfig : IDataFlowPluginConfig
    {
        public IPluginConfig Config { get; set; }

        public List<ITable> InputTables { get; set; }
    }
}
