using System.Collections.Generic;
using IndependExecution.Interfaces.Plugin;

namespace ETLEngine.Plugin.DataTable;

public class DataTablePluginConfig : IPluginConfig
{
    public Dictionary<string, List<string>> Tables;

    public DataTablePluginConfig()
    {
        Tables = new Dictionary<string, List<string>>();
    }
}