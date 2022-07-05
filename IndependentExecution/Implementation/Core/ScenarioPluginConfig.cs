using System.Collections.Generic;
using IndependentExecution.Interfaces.Core;
using IndependentExecution.Interfaces.Plugin;
#pragma warning disable CS8618

namespace IndependentExecution.Implementation.Core
{
    public record ScenarioPluginConfig : IScenarioPluginConfig
    {
        public IPluginConfig Config { get; set; }

        public List<InputTableSchema> InputTables { get; set; }
    }
}
