﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IndependentExecution.Dto.Link;
using IndependentExecution.Interfaces.Core;
using IndependentExecution.Interfaces.Plugin;
using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using Mohaymen.DataFlowManagement.Plugin;
#pragma warning disable CS8618

namespace ETLEngine.Plugin
{
    public class DataTablePlugin : ConstantSchemaPlugin<IBaseTable>, IPlugin
    {
        public string TypeId => "DataTable";
        public string Location { get; set; }
        public string Note { get; set; }

        public IPluginConfigurable Plugin { get; set; }

        public List<IInputPort> Inputs { get; private set; }
        private List<IOutputPort> _outputs;
        public List<IOutputPort> Outputs { get { return _outputs; } }

        private readonly DataTableConfig _config;

        public DataTablePlugin(string id, Socket socket, IProgress<NodeStateChange>? progress = null)
            : base(id, socket, progress)
        {
            _config = new DataTableConfig();

            this.Inputs = new List<IInputPort>(){ new NonePort()};
            this._outputs =new List<IOutputPort>(){ new MultipleSpecificPort()};
        }

        public override Task<Dictionary<string, IBaseTable>> ExecuteAsync(Dictionary<string, IBaseTable>? input,
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execute DataTablePlugin, id:{Id}");

            return Task.FromResult<Dictionary<string, IBaseTable>>(null!);
        }

        public IPluginConfig GetConfig()
        {
            return _config;
        }

        public void ChangeConfig(IPluginConfig config)
        {
            var dt = config as DataTableConfig;

            this._outputs.Clear();
            foreach (var item in dt!.Tables)
            {
                this._outputs.Add(new OutPort()
                {
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
