namespace IndependExecution.Interfaces.Plugin
{
    public interface IPlugin : IPluginConfigurable
    {
        public string TypeId { get; }
        public string Location { get; set; }
        public string Note { get; set; }
        //public Port Inputs { get; set; }
        //public Port Outputs { get; set; }
    }
}
