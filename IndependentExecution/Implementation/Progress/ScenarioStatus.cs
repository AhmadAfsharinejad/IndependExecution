using System.Collections.Generic;

namespace IndependentExecution.Implementation.Progress
{
    //TODO staus is good name?
    public record ScenarioStatus
    {
        public List<PluginStatus> Nodes { get; }

        public List<LinkStatus> Links { get; }
        
        public ScenarioStatus()
        {
            this.Nodes = new List<PluginStatus>();
            Links = new List<LinkStatus>();
        }
    }
}
