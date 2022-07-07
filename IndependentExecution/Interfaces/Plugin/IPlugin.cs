using System.Collections.Generic;
using IndependentExecution.Dto;

namespace IndependentExecution.Interfaces.Plugin
{
    public interface IPlugin : IPluginConfigurable
    {
        public PluginTypeId TypeId { get;  }
        public string Location { get; set;}
        public string Note { get; set; }
        public List<Port> Inputs { get;  set;}
        public List<Port> Outputs { get; set;}
    }
}
