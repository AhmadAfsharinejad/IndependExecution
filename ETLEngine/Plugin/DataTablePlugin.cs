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

namespace IndependExecution.Sample.Plugin
{
    public class DataTablePlugin : ConstantSchemaPlugin<IBaseTable>, IPlugin
    {
        public string TypeId => "DataTable";
        public string Location { get; set; }
        public string Note { get; set; }

        public IPluginConfigurable plugin { get; set; }

        public IInputPort Inputs { get; private set; }
        private MultipleSpecificPort _outputs;
        public IOutputPort Outputs { get { return _outputs; } }

        //TODO plugin link vorodi khorojisho bege
        private readonly DataTableConfig config;

        public DataTablePlugin(string id, Socket socket, IProgress<NodeStateChange> progress = null)
            : base(id, socket, progress)
        {
            config = new DataTableConfig();

            this.Inputs = new NonePort();
            this._outputs = new MultipleSpecificPort();
        }

        public override Task<Dictionary<string, IBaseTable>> ExecuteAsync(Dictionary<string, IBaseTable> input,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execute DataTablePlugin, id:{Id}");

            return Task.FromResult<Dictionary<string, IBaseTable>>(null);
        }

        public IPluginConfig GetConfig()
        {
            return config;
        }

        public void ChangeConfig(IPluginConfig config)
        {
            var dt = config as DataTableConfig;

            this._outputs.Ports.Clear();
            int index = 0;
            foreach (var item in dt.Tables)
            {
                this._outputs.Ports.Add(new SpecificPort()
                {
                    Name = (index++).ToString(),
                    TypeId = item.Key,
                });
            }
        }
    }

    public class DataTableConfig : IPluginConfig
    {
        public Dictionary<string, List<string>> Tables;

        public DataTableConfig()
        {
            Tables = new Dictionary<string, List<string>>();
        }
    }
}
