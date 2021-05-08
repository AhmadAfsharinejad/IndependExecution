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
    public class DataTablePlugin : IPlugin
    {
        public string TypeId => "DataTable";
        public string Location { get; set; }
        public string Note { get; set; }

        public IPluginConfigurable plugin { get; set; }

        //TODO plugin link vorodi khorojisho bege
        public DataTablePlugin(string id, Socket socket, IProgress<NodeStateChange<string>> progress = null)
        {
            this.plugin = new DataTablePluginExecuter(id, socket, progress);
        }
    }

    public class DataTablePluginExecuter : ConstantSchemaPlugin<IBaseTable>, IPluginConfigurable
    {

        private readonly DataTableConfig config;

        public DataTablePluginExecuter(string id, Socket socket, IProgress<NodeStateChange<string>> progress = null)
            : base(id, socket, progress)
        {
            config = new DataTableConfig();
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
            config = config as DataTableConfig;
        }
    }

    public class DataTableConfig : IPluginConfig
    {
        public List<string> Columns;

        public DataTableConfig()
        {
            Columns = new List<string>();
        }
    }
}
