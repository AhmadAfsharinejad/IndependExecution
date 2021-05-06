using IndependExecution.Interfaces.Plugin;
using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlowPluginConfig
    {
        IPluginConfig Config { get; }
        List<ITable> InputTables { get; }
    }
}
