using IndependExecution.Interfaces.Core;
using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using Mohaymen.DataFlowExecutor.Core.Graph.Progress;
using Mohaymen.DataFlowManagement.Plugin;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IndependExecution.Sample.Plugin
{
    public class DataTablePlugin : ConstantSchemaPlugin<IBaseTable>
    {
        public DataTablePlugin(string id, Socket socket, IProgress<NodeStateChange<string>> progress = null) 
            : base(id, socket, progress)
        {
        }

        public override Task<Dictionary<string, IBaseTable>> ExecuteAsync(Dictionary<string, IBaseTable> input, 
            CancellationToken cancellationToken)
        {
            Console.WriteLine($"Execute DataTablePlugin, id:{Id}");

            return Task.FromResult<Dictionary<string, IBaseTable>>(null);
        }
    }
}
