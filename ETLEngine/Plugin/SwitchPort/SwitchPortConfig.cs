using System.Collections.Generic;
using IndependExecution.Interfaces.Plugin;

namespace ETLEngine.Plugin.SwitchPort;

public class SwitchPortConfig : IPluginConfig
{
    public List<string> Columns;

    public SwitchPortConfig()
    {
        Columns = new List<string>();
    }
}