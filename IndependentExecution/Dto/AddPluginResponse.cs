using System.Collections.Generic;

#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record AddPluginResponse
    {
        public PluginId Id { get; init;}
        public PluginTypeId TypeId { get; init;}
        public string Name { get; init; }
        public string Location { get; init; }
        public List<Port> InputPorts { get; init; }
        public List<Port> OutputPorts { get; init; }
    }
}