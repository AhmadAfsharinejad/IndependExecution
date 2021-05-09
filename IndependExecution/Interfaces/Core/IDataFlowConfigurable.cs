using IndependExecution.Dto;

namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlowConfigurable
    {
        void ChangeConfig(ChangeConfigRequest changeConfigRequest);
        IDataFlowPluginConfig GetConfig(string nodeId);
    }
}
