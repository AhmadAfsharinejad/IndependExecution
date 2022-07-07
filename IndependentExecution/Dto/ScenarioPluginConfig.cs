using System.Collections.Generic;
using IndependentExecution.Interfaces.Core;
using IndependentExecution.Interfaces.Plugin;

#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record ScenarioPluginConfig : IScenarioPluginConfig
    {
        public IPluginConfig Config { get; init; }

        public List<InputTableSchema> InputTables { get; init; }
    }
}
