using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IndependentExecution.Dto;
using IndependentExecution.Interfaces.Core;
using IndependentExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using Mohaymen.DataFlowManagement.Plugin;

#pragma warning disable CS8618

namespace ETLEngine.Plugin
{
    public class SwitchPortPlugin : ConstantSchemaPlugin<IBaseTable>, IPlugin
    {
        public PluginTypeId TypeId => new PluginTypeId("SwitchPort");
        public string Location { get; set; }
        public string Note { get; set; }

        public IPluginConfigurable Plugin { get; set; }

        public List<Port> Inputs { get; set; }
        public List<Port> Outputs { get; set; }

        private readonly SwitchPortConfig _config;


        public SwitchPortPlugin(PluginId id, Socket socket, IProgress<NodeStateChange>? progress = null)
            : base(id.ToString(), socket, progress)
        {
            _config = new SwitchPortConfig();

            Inputs = new List<Port> { new Port() };
            Outputs = new List<Port> { new Port() };
        }

        public override Task<Dictionary<string, IBaseTable>> ExecuteAsync(Dictionary<string, IBaseTable>? input,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execute SwitchPort, id:{Id}");

            return Task.FromResult<Dictionary<string, IBaseTable>>(null!);
        }

        public IPluginConfig GetConfig()
        {
            return _config;
        }

        public void ChangeConfig(IPluginConfig config)
        {
            config = (config! as SwitchPortConfig)!;
        }
    }

    public class SwitchPortConfig : IPluginConfig
    {
        public List<string> Columns;

        public SwitchPortConfig()
        {
            Columns = new List<string>();
        }
    }
}