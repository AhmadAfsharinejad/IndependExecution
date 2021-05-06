using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using System.Collections.Generic;

namespace ETLEngine.Implementention.Core
{
    public class PluginContainer : IPluginContainer
    {
        private readonly Dictionary<string, IPlugin> plugins;

        public PluginContainer()
        {
            plugins = new Dictionary<string, IPlugin>();
        }

        public void AddPlugin(IPlugin plugin)
        {
            plugins[plugin.Id] = plugin;
        }

        public IPlugin GetPlugin(string id)
        {
            return plugins[id];
        }
    }
}
