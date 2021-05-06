using IndependExecution.Dto;
using IndependExecution.Implementention.Core;
using IndependExecution.Progress;
using IndependExecution.Sample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using IndependExecution.Implementention.Progress;
using IndependExecution.Sample.Plugin;
using ETLEngine.Plugin;
using System.Threading.Tasks;

namespace IndependExecution.Sample
{
    public class DataFlowRunner
    {
        private List<NodeStatus> _nodeStatusList;
        private List<LinkStatus> _linkStatusList;
        private Dictionary<string, NodeStatus> plugins = new Dictionary<string, NodeStatus>();

        public void Run()
        {
            var dataFlowProgress = new DataFlowProgress();
            var scenarioContainer = new ScenarioContainer(dataFlowProgress);
            var dataFlowMediator = new DataFlowMediator(scenarioContainer);


            dataFlowProgress.ProgressChanged += DataFlowProgress_ProgressChanged;

            var scenario = new Scenario("s1");
            dataFlowMediator.AddScenario(scenario);

            dataFlowMediator.AddNode(scenario, new AddNodeRequest() { Location = "0", TypeId = "DataTable" });
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            var dataTableConfig = dataFlowMediator.GetConfig(scenario, plugins["DataTable"].Id);

            dataFlowMediator.ChangeConfig(scenario, new ChangeConfigRequest()
            {
                config = new DataTableConfig()
                {
                    Columns = new List<string> { "c1", "c2" }
                },
                nodeId = plugins["DataTable"].Id,
            });



            dataFlowMediator.AddNode(scenario, new AddNodeRequest() { Location = "1", TypeId = "SwitchPort" });
            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();



            dataFlowMediator.AddLink(scenario, new AddLinkRequest()
            {
                SourceId = plugins["DataTable"].Id,
                TargetId = plugins["SwitchPort"].Id,
            });

            Task.Delay(TimeSpan.FromMilliseconds(200)).Wait();


            var switchPortConfig = dataFlowMediator.GetConfig(scenario, plugins["SwitchPort"].Id);
            dataFlowMediator.ChangeConfig(scenario, new ChangeConfigRequest()
            {
                config = new SwitchPortConfig()
                {
                    Columns = new List<string> { "c1", "c2" }
                },
                nodeId = plugins["SwitchPort"].Id,
            });


            //dataFlowMediator.AddNode(scenario, new AddNodeRequest() { Location = "1", TypeId = "SakhtarVorodi" });
            //dataFlowMediator.AddNode(scenario, new AddNodeRequest() { Location = "2", TypeId = "zakhireMovaghat" });



            //var jadvalNode = NodeFactory.Create("1", "Jadval");
            //var sakhtarNode = NodeFactory.Create("2", "SakhtarVorodi");
            //var zakhireNode = NodeFactory.Create("3", "zakhireMovaghat");

            //var jadvalConfig = dataFlow.GetConfig<jadavalDto>(jadvalNode);
            //dataFlow.ChangeConfig<jadavalDto>(jadvalNode, new jadavalDto() { SelectedTable = "t1" });


            //var jadvalMaps = dataFlow.GetMaps(jadvalNode);

            //dataFlow.AddLink(jadvalNode, sakhtarNode, jadvalMaps.First());


            //var sakhtarConfig = dataFlow.GetConfig<SakhtarVorodiDto>(sakhtarNode);
            //dataFlow.ChangeConfig<SakhtarVorodiDto>(sakhtarNode,
            //    new SakhtarVorodiDto()
            //    {
            //        outputs = new List<string>() { sakhtarConfig.InputTables.First().Columns.Select(x => x.Id).First() }
            //    });


            //var sakhtarMaps = dataFlow.GetMaps(sakhtarNode);


            //dataFlow.AddLink(sakhtarNode, zakhireNode, sakhtarMaps.First());


            dataFlowMediator.Run(scenario, new RunRequest() { NodeIds = new List<string>() { _nodeStatusList.Last().Id } });
        }

        private void DataFlowProgress_ProgressChanged(object sender, Implementention.Progress.DataFlowStatus e)
        {
            foreach (var node in e.Nodes)
            {
                plugins[node.TypeId] = node;
            }

            Console.WriteLine("\\\\\\\\\\\\\\\\");
            _nodeStatusList = e.Nodes.ToList();
            _linkStatusList = e.Links.ToList();

            Console.WriteLine("nodes:");
            Console.WriteLine(string.Join("\n", e.Nodes.Select(x => x.ToString())));
            Console.WriteLine("--");
            Console.WriteLine("links:");
            Console.WriteLine(string.Join("\n", e.Links.Select(x => x.ToString())));
            Console.WriteLine("--");
        }
    }
}
