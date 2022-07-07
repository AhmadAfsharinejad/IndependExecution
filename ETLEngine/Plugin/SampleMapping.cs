using System.Collections.Generic;
using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;

namespace ETLEngine.Plugin
{
    public class SampleMapping : IMapping
    {
        private Dictionary<string, string> _map;

        public SampleMapping(Dictionary<string, string> map)
        {
            _map = map;
        }
        public Dictionary<string, string> GetMap()
        {
            return _map;
        }
    }
}
