using System.Collections.Generic;
using IndependentExecution.Dto.Link;
#pragma warning disable CS8618

namespace IndependentExecution.Implementation.Progress
{
    public record PluginStatus
    {
        public PluginStatus(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public string State { get; set; }
        public List<IInputPort> InputPorts { get; set; }
        public List<IOutputPort> OutputPorts { get; set; }

        public override string ToString()
        {
            return $"id:{Id}, State:{State}";
        }
    }
}
