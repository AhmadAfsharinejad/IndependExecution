using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface IPluginConfig<TConfig>
    {
        TConfig Config { get; }
        List<ITable> InputTables { get; }
    }
}
