using System.Collections.Generic;
using IndependExecution.Interfaces.Plugin;

namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlowPluginConfig
    {
        IPluginConfig Config { get; }
        List<ITable> InputTables { get; }
    }
}
