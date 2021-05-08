using System.Collections.Generic;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IPlugin
    {
        public IPluginConfigurable plugin { get; }
        public string TypeId { get; }
        public string Location { get; set; }
        public string Note { get; set; }
        public Port Inputs { get; set; }
        public Port Outputs { get; set; }
    }
}
