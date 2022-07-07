using System.Collections.Generic;

#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record PluginStatus
    {
        public string Id { get; init; }
        public string TypeId { get; init; }
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