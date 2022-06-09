using System.Collections.Generic;
using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using Mohaymen.DataFlowManagement.Model;

namespace ETLEngine.Plugin
{
    public class SocketForTest : Socket
    {
        /// <summary>
        /// you can use Mapping too, another version with Mapping is commented down here.
        /// </summary>
        /// <param name="parentOutputsSchemas"></param>
        protected override void CalcRightSide(IEnumerable<Dictionary<string, TableSchema>>? parentOutputsSchemas)
        {
            foreach (var item in parentOutputsSchemas)
            {
                foreach (var item2 in item)
                    RightSide[item2.Key] = item2.Value;
            }
        }

        public SocketForTest(IMapping mapping)
        {
            Mapping = mapping;
        }

        //protected override void CalcRightSide(IEnumerable<Dictionary<string, TableSchema>>? parentOutputsSchemas)
        //{
        //    Dictionary<string, TableSchema>? schemas = new Dictionary<string, TableSchema>();
        //    foreach (var item in parentOutputsSchemas)
        //        foreach (var it in item)
        //            schemas.Add(it.Key, it.Value);
        //    foreach (var item in Mapping.GetMap())
        //    {
        //        if (schemas.ContainsKey(item.Value))
        //            RightSide.Add(item.Key, schemas[item.Value]);
        //    }
        //}
    }
}
