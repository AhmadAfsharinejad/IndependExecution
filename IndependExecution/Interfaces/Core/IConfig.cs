using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface IConfig
    {
        void ChangeConfig<TConfig>(INode node, TConfig config);
        IPluginConfig<TConfig> GetConfig<TConfig>(INode node);
        List<IMapLink> GetMaps(INode node);
    }
}
