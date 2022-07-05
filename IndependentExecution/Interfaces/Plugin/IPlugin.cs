using System.Collections.Generic;
using IndependentExecution.Dto.Link;

namespace IndependentExecution.Interfaces.Plugin
{
    public interface IPlugin : IPluginConfigurable
    {
        public string TypeId { get; }
        public string Location { get; set; }
        public string Note { get; set; }
        public List<IInputPort> Inputs { get;  }
        public List<IOutputPort> Outputs { get; }
    }
}
