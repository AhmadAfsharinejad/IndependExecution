using IndependExecution.Interfaces.Plugin;

namespace IndependExecution.Dto
{
    public class ChangeConfigRequest
    {
        public string nodeId { get; set; }
        public IPluginConfig config { get; set; }
    }
}
