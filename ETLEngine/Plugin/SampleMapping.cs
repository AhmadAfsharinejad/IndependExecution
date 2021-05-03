using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using System.Collections.Generic;

namespace ETLEngine.Plugin
{
    public class SampleMapping : IMapping
    {
        private Dictionary<string, string> map;

        public SampleMapping(Dictionary<string, string> map)
        {
            this.map = map;
        }
        public Dictionary<string, string> GetMap()
        {
            return map;
        }
    }
}
