using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETLEngine.Implementention.Core;
using ETLEngine.Plugin;
using IndependentExecution.Dto;
using IndependentExecution.Implementation.Progress;

namespace IndependentExecution.Sample
{
    public class DataFlowRunner
    {
        private List<PluginStatus>? _nodeStatusList;
        private List<LinkStatus>? _linkStatusList;

        public void Run()
        {
            var dataFlowProgress = new ScenarioProgress();
            var scenarioContainer = new ScenarioContainer(dataFlowProgress);
            var dataFlowMediator = new ScenarioMediator(scenarioContainer);


            dataFlowProgress.ProgressChanged += DataFlowProgress_ProgressChanged;


            var scenarioId = "s1";
            dataFlowMediator.AddScenario(scenarioId);

            Console.WriteLine("--add DataTable node");

            dataFlowMediator.AddPlugin(scenarioId, new AddPluginRequest() { Location = "0", TypeId = "DataTable", Id = "DataTable1"});
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--get DataTable config");

            var dataTableConfig = dataFlowMediator.GetConfig(scenarioId, GetPlugin("DataTable1").Id);

            Console.WriteLine("--change DataTable config");
            var dic = new Dictionary<string, List<string>>
            {
                { "t1", new List<string>() { "c1", "c2" } }
            };
            dataFlowMediator.ChangeConfig(scenarioId, new ChangeConfigRequest()
            {
                Config = new DataTableConfig()
                {
                    Tables = dic
                },
                PluginId = GetPlugin("DataTable1").Id,
            });


            Console.WriteLine("--add SwitchPort node");
            dataFlowMediator.AddPlugin(scenarioId, new AddPluginRequest() { Location = "1", TypeId = "SwitchPort", Id = "SwitchPort1"});
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--add DataTable-SwitchPort link");
            dataFlowMediator.AddLink(scenarioId, new AddLinkRequest()
            {
                SourceId = GetPlugin("DataTable1").Id,
                TargetId = GetPlugin("SwitchPort1").Id,
                SourceMapLink = GetPlugin("DataTable1")!.OutputPorts.FirstOrDefault()!.ToString(),
            });

            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--get SwitchPort config");
            var switchPortConfig = dataFlowMediator.GetConfig(scenarioId, GetPlugin("SwitchPort1").Id);

            Console.WriteLine("--change SwitchPort config");
            dataFlowMediator.ChangeConfig(scenarioId, new ChangeConfigRequest()
            {
                Config = new SwitchPortConfig()
                {
                    Columns = new List<string> { "c1", "c2" }
                },
                PluginId = GetPlugin("SwitchPort1").Id,
            });
        

            Console.WriteLine("--run SwitchPort node");
            dataFlowMediator.Run(scenarioId, new RunRequest() { NodeIds = new List<string>() { _nodeStatusList!.Last().Id } });
        }

        private void DataFlowProgress_ProgressChanged(object? sender, ScenarioStatus e)
        {
      
            Console.WriteLine("-----------------------");
            _nodeStatusList = e.Nodes.ToList();
            _linkStatusList = e.Links.ToList();

            Console.WriteLine("nodes:");
            Console.WriteLine(string.Join("\n", e.Nodes.Select(x => x.ToString())));
            Console.WriteLine("links:");
            Console.WriteLine(string.Join("\n", e.Links.Select(x => x.ToString())));
            Console.WriteLine(string.Empty);
        }

        private PluginStatus GetPlugin(string id)
        {
             return _nodeStatusList!.First(x => x.Id == id);
        }
    }
}
