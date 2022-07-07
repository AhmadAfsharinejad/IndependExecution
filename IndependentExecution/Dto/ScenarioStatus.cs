using System.Collections.Generic;

namespace IndependentExecution.Dto
{
    public record ScenarioStatus
    {
        public List<PluginStatus> Plugins { get; }

        public List<LinkStatus> Links { get; }
        
        public ScenarioStatus()
        {
            Plugins = new List<PluginStatus>();
            Links = new List<LinkStatus>();
        }
    }
}
