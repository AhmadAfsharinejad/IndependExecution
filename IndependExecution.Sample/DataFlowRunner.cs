using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETLEngine.Dto;
using ETLEngine.Implementention.Core;
using ETLEngine.Plugin;
using ETLEngine.Plugin.DataTable;
using ETLEngine.Plugin.SwitchPort;
using IndependExecution.Dto;
using IndependExecution.Dto.Link;
using IndependExecution.Implementention.Core;
using IndependExecution.Implementention.Progress;

namespace IndependExecution.Sample
{
    public class DataFlowRunner
    {
        private List<NodeStatus> _nodeStatusList;
        private List<LinkStatus> _linkStatusList;

        public void Run()
        {
            var dataFlowProgress = new DataFlowProgress();
            var scenarioContainer = new ScenarioContainer(dataFlowProgress);
            var dataFlowMediator = new DataFlowMediator(scenarioContainer);


            dataFlowProgress.ProgressChanged += DataFlowProgress_ProgressChanged;


            var scenario = new Scenario("s1");
            dataFlowMediator.AddScenario(scenario);

            Console.WriteLine("--add DataTable node");

            dataFlowMediator.AddNode(scenario, new AddNodeRequest { Location = "0", TypeId = "DataTable" });
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--get DataTable config");

            var dataTableConfig = dataFlowMediator.GetConfig(scenario, GetNode("DataTable").Id);

            Console.WriteLine("--change DataTable config");
            var dic = new Dictionary<string, List<string>>();
            dic.Add("t1", new List<string> { "c1", "c2" });
            dataFlowMediator.ChangeConfig(scenario, new ChangeConfigRequest
            {
                Config = new DataTablePluginConfig
                {
                    Tables = dic
                },
                NodeId = GetNode("DataTable").Id,
            });


            Console.WriteLine("--add SwitchPort node");
            dataFlowMediator.AddNode(scenario, new AddNodeRequest { Location = "1", TypeId = "SwitchPort" });
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--add DataTable-SwitchPort link");
            dataFlowMediator.AddLink(scenario, new AddLinkRequest
            {
                SourceId = GetNode("DataTable").Id,
                TargetId = GetNode("SwitchPort").Id,
                SourceMapLink = (GetNode("DataTable").OutputPorts as MultipleSpecificPort).Ports.First().TypeId,
            });

            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            Console.WriteLine("--get SwitchPort config");
            var switchPortConfig = dataFlowMediator.GetConfig(scenario, GetNode("SwitchPort").Id);

            Console.WriteLine("--change SwitchPort config");
            dataFlowMediator.ChangeConfig(scenario, new ChangeConfigRequest
            {
                Config = new SwitchPortConfig
                {
                    Columns = new List<string> { "c1", "c2" }
                },
                NodeId = GetNode("SwitchPort").Id,
            });
        

            Console.WriteLine("--run SwitchPort node");
            dataFlowMediator.Run(scenario, new RunRequest { NodeIds = new List<string> { _nodeStatusList.Last().Id } });
        }

        private void DataFlowProgress_ProgressChanged(object? sender, DataFlowStatus e)
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

        private NodeStatus GetNode(string type)
        {
            return _nodeStatusList.First(x => x.TypeId == type);
        }
    }
}
