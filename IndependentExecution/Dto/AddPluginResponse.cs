using System.Collections.Generic;

#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record AddPluginResponse
    {
        public string Id { get; init;}
        public string TypeId { get; init;}
        public string Name { get; init; }
        public string Location { get; init; }
        public List<Port> InputPorts { get; init; }
        public List<Port> OutputPorts { get; init; }
    }
}