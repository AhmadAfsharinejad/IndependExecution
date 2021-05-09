using IndependExecution.Dto.Link;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IPlugin : IPluginConfigurable
    {
        public string TypeId { get; }
        public string Location { get; set; }
        public string Note { get; set; }
        public IInputPort Inputs { get;  }
        public IOutputPort Outputs { get; }
    }
}
