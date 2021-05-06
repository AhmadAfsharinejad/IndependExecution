namespace IndependExecution.Interfaces.Plugin
{
    public interface IPluginConfigurable
    {
        void ChangeConfig(IPluginConfig config);
        IPluginConfig GetConfig();
    }
}
