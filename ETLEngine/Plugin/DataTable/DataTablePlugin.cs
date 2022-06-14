using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IndependExecution.Dto.Link;
using IndependExecution.Interfaces.Core;
using IndependExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using Mohaymen.DataFlowManagement.Plugin;

namespace ETLEngine.Plugin.DataTable
{
    public class DataTablePlugin : ConstantSchemaPlugin<IBaseTable>, IPlugin
    {
        public string TypeId => "DataTable";
        public string Location { get; set; }
        public string Note { get; set; }

        public IPluginConfigurable Plugin { get; set; }

        public IInputPort Inputs { get; private set; }
        private MultipleSpecificPort _outputs;
        public IOutputPort Outputs { get { return _outputs; } }

        private readonly DataTablePluginConfig _pluginConfig;

        public DataTablePlugin(string id, Socket socket, IProgress<NodeStateChange>? progress = null)
            : base(id, socket, progress)
        {
            _pluginConfig = new DataTablePluginConfig();

            Inputs = new NonePort();
            _outputs = new MultipleSpecificPort();
        }

        public override Task<Dictionary<string, IBaseTable>> ExecuteAsync(Dictionary<string, IBaseTable>? input,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execute DataTablePlugin, id:{Id}");

            return Task.FromResult<Dictionary<string, IBaseTable>>(new Dictionary<string, IBaseTable>());
        }

        public IPluginConfig GetConfig()
        {
            return _pluginConfig;
        }

        public void ChangeConfig(IPluginConfig config)
        {
            var dt = config as DataTablePluginConfig;

            _outputs.Ports.Clear();
            int index = 0;
            foreach (var item in dt.Tables)
            {
                _outputs.Ports.Add(new SpecificPort
                {
                    Name = (index++).ToString(),
                    TypeId = item.Key,
                });
            }
        }
    }
}
