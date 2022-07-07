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
        private List<PluginStatus>? _pluginStatusList;
        private List<LinkStatus>? _linkStatusList;

        public void Run()
        {
            var dataFlowProgress = new ScenarioProgress();
            var scenarioContainer = new ScenarioContainer(dataFlowProgress);
            var dataFlowMediator = new ScenarioMediator(scenarioContainer);


            dataFlowProgress.ProgressChanged += DataFlowProgress_ProgressChanged;


            var scenarioId = new ScenarioId("s1") ;
            dataFlowMediator.AddScenario(scenarioId);

            Console.WriteLine("--add DataTable plugin");

            dataFlowMediator.AddPlugin(scenarioId, new AddPluginRequest { Location = "0", TypeId = new PluginTypeId("DataTable") , Id = new PluginId("DataTable1") });
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--get DataTable config");

            var dataTableConfig = dataFlowMediator.GetConfig(scenarioId, GetPlugin(new PluginId("DataTable1")).Id);

            Console.WriteLine("--change DataTable config");
            var dic = new Dictionary<string, List<string>>
            {
                { "t1", new List<string> { "c1", "c2" } }
            };
            dataFlowMediator.ChangeConfig(scenarioId, new ChangeConfigRequest
            {
                Config = new DataTableConfig
                {
                    Tables = dic
                },
                PluginId = GetPlugin(new PluginId("DataTable1")).Id,
            });


            Console.WriteLine("--add SwitchPort plugin");
            dataFlowMediator.AddPlugin(scenarioId, new AddPluginRequest { Location = "1", TypeId = new PluginTypeId("SwitchPort") , Id = new PluginId( "SwitchPort1")});
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--add DataTable-SwitchPort link");
            dataFlowMediator.AddLink(scenarioId, new AddLinkRequest
            {
                Id = new LinkId($"{Guid.NewGuid()}"),
                SourceId = GetPlugin(new PluginId("DataTable1")).Id,
                TargetId = GetPlugin(new PluginId("SwitchPort1")).Id,
                SourcePortId = GetPlugin(new PluginId("DataTable1"))!.OutputPorts.FirstOrDefault()?.Id,
            });

            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--get SwitchPort config");
            var switchPortConfig = dataFlowMediator.GetConfig(scenarioId, GetPlugin( new PluginId("SwitchPort1")).Id);

            Console.WriteLine("--change SwitchPort config");
            dataFlowMediator.ChangeConfig(scenarioId, new ChangeConfigRequest
            {
                Config = new SwitchPortConfig
                {
                    Columns = new List<string> { "c1", "c2" }
                },
                PluginId = GetPlugin( new PluginId("SwitchPort1")).Id,
            });
        

            Console.WriteLine("--run SwitchPort plugin");
            dataFlowMediator.Run(scenarioId, new RunRequest { PluginIds = new List<PluginId> { _pluginStatusList!.Last().Id } });
        }

        private void DataFlowProgress_ProgressChanged(object? sender, ScenarioStatus e)
        {
      
            Console.WriteLine("-----------------------");
            _pluginStatusList = e.Plugins.ToList();
            _linkStatusList = e.Links.ToList();

            Console.WriteLine("nodes:");
            Console.WriteLine(string.Join("\n", e.Plugins.Select(x => x.ToString())));
            Console.WriteLine("links:");
            Console.WriteLine(string.Join("\n", e.Links.Select(x => x.ToString())));
            Console.WriteLine(string.Empty);
        }

        private PluginStatus GetPlugin(PluginId id)
        {
             return _pluginStatusList!.First(x => x.Id == id);
        }
    }
}
