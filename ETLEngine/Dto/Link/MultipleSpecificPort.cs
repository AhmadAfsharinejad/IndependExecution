using System.Collections.Generic;

namespace ETLEngine.Dto.Link
{
    public class MultipleSpecificPort : Port
    {
        public List<MultipleSpecificPort> Ports { get; set; }
    }
}
