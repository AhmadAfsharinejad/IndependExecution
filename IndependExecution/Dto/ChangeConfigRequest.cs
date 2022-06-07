using IndependExecution.Interfaces.Plugin;

namespace IndependExecution.Dto
{
    public class ChangeConfigRequest
    {
        public string NodeId { get; set; }
        public IPluginConfig Config { get; set; }
    }
}
