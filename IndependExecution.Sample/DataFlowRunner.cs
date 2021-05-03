using IndependExecution.Dto;
using IndependExecution.Implementention.Core;
using IndependExecution.Progress;
using IndependExecution.Sample.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndependExecution.Sample
{
    public class DataFlowRunner
    {
        public void Run()
        {
            var dataFlowProgress = new DataFlowProgress();
            var scenarioContainer = new ScenarioContainer(dataFlowProgress);
            var dataFlowMediator = new DataFlowMediator(scenarioContainer);


            dataFlowProgress.ProgressChanged += DataFlowProgress_ProgressChanged;

            var scenario = new Scenario("s1");
            dataFlowMediator.AddScenario(scenario);

            dataFlowMediator.AddNode(scenario, new AddNodeRequest() { Location = "0", TypeId = "Jadval" });
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


            dataFlowMediator.Run(scenario, new RunRequest() { NodeIds = new List<string>() { "0" } });
        }

        private void DataFlowProgress_ProgressChanged(object sender, Implementention.Progress.DataFlowStatus e)
        {
            Console.WriteLine("\\\\\\\\\\\\\\\\");
            foreach (var node in e.Nodes)
                Console.WriteLine(string.Join("\n", e.Nodes.Select(x => x.ToString())));
        }
    }
}
