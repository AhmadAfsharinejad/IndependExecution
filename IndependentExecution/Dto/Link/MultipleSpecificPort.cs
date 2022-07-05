using System.Collections.Generic;
#pragma warning disable CS8618

namespace IndependentExecution.Dto.Link
{
    public record MultipleSpecificPort : IInputPort, IOutputPort
    {
        public List<SpecificPort> Ports { get; set; }
    }
}
