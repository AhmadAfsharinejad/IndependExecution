using IndependExecution.Implementention.Core;
using IndependExecution.Model.Plugin;
using IndependExecution.Sample.Factory;
using System.Collections.Generic;
using System.Linq;

namespace IndependExecution.Sample
{
    public class DataFlowRunner
    {
        public void Run()
        {
            var df = new DataFlow();

            var jadvalNode = NodeFactory.Create("1", "Jadval");
            var sakhtarNode = NodeFactory.Create("2", "SakhtarVorodi");
            var zakhireNode = NodeFactory.Create("3", "zakhireMovaghat");

            df.AddNode(jadvalNode);
            df.AddNode(sakhtarNode);
            df.AddNode(zakhireNode);

            var jadvalConfig = df.GetConfig<jadavalDto>(jadvalNode);
            df.ChangeConfig<jadavalDto>(jadvalNode, new jadavalDto() { SelectedTable = "t1" });

            var jadvalMaps = df.GetMaps(jadvalNode);

            df.AddLink(jadvalNode, sakhtarNode, jadvalMaps.First());


            var sakhtarConfig = df.GetConfig<SakhtarVorodiDto>(sakhtarNode);
            df.ChangeConfig<SakhtarVorodiDto>(sakhtarNode,
                new SakhtarVorodiDto()
                {
                    outputs = new List<string>() { sakhtarConfig.InputTables.First().Columns.Select(x => x.Id).First() }
                });


            var sakhtarMaps = df.GetMaps(sakhtarNode);


            df.AddLink(sakhtarNode, zakhireNode, sakhtarMaps.First());


            df.RunAll();
        }
    }
}
