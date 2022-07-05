using Mohaymen.DataFlowExecutor.Core.Core.Graph.Elements;
using System.Collections.Generic;

namespace ETLEngine.Plugin
{
    public class SampleMapping : IMapping
    {
        private Dictionary<string, string> _map;

        public SampleMapping(Dictionary<string, string> map)
        {
            this._map = map;
        }
        public Dictionary<string, string> GetMap()
        {
            return _map;
        }
    }
}
