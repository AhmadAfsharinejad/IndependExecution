using IndependExecution.Dto.Link;
using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using Mohaymen.DataFlowManagement.Plugin;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ETLEngine.Plugin
{
    public class SwitchPortPlugin : ConstantSchemaPlugin<IBaseTable>, IPlugin
    {
        public string TypeId => "SwitchPort";
        public string Location { get; set; }
        public string Note { get; set; }

        public IPluginConfigurable plugin { get; set; }

        public IInputPort Inputs { get; private set; }
        public IOutputPort Outputs { get; private set; }

        private readonly SwitchPortConfig config;


        public SwitchPortPlugin(string id, Socket socket, IProgress<NodeStateChange> progress = null)
            : base(id, socket, progress)
        {
            config = new SwitchPortConfig();

            this.Inputs = new FinitePort() { MaxPort = 1 };
            this.Outputs = new OutPort();
        }

        public override Task<Dictionary<string, IBaseTable>> ExecuteAsync(Dictionary<string, IBaseTable> input,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execute SwitchPort, id:{Id}");

            return Task.FromResult<Dictionary<string, IBaseTable>>(null);
        }

        public IPluginConfig GetConfig()
        {
            return config;
        }

        public void ChangeConfig(IPluginConfig config)
        {
            config = config as SwitchPortConfig;
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
