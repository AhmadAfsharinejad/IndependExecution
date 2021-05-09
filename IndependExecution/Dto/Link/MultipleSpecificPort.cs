using System.Collections.Generic;

namespace IndependExecution.Dto.Link
{
    public class MultipleSpecificPort : IInputPort, IOutputPort
    {
        public List<SpecificPort> Ports { get; set; }

        public MultipleSpecificPort()
        {
            Ports = new List<SpecificPort>();
        }
    }
}
