using System.Collections.Generic;
using IndependentExecution.Interfaces.Plugin;

namespace IndependentExecution.Interfaces.Core
{
    public interface IScenarioPluginConfig
    {
        IPluginConfig Config { get; }
        List<InputTableSchema> InputTables { get; }
    }
}
