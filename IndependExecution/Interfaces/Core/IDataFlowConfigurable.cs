using IndependExecution.Dto;
using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlowConfigurable
    {
        void ChangeConfig(ChangeConfigRequest changeConfigRequest);
        IDataFlowPluginConfig GetConfig(string nodeId);
        List<IMapLink> GetMaps(string nodeId);
    }
}
