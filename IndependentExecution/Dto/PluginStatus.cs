using System.Collections.Generic;

#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record PluginStatus
    {
        public PluginId Id { get; init; }
        public PluginTypeId TypeId { get; init; }
        public string Location { get; set; }
        public string State { get; set; }
        public List<Port> InputPorts { get; set; }
        public List<Port> OutputPorts { get; set; }

        public override string ToString()
        {
            return $"id:{Id}, State:{State}";
        }
    }
}