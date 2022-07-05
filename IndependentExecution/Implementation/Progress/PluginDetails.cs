using System.Collections.Generic;
using IndependentExecution.Dto.Link;
#pragma warning disable CS8618

namespace IndependentExecution.Implementation.Progress
{
    public record PluginDetails
    {
        public PluginDetails(string id, string typeId)
        {
            Id = id;
            TypeId = typeId;
        }

        public string Id { get; }
        public string TypeId { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public List<IInputPort> InputPorts { get; set; }
        public List<IOutputPort> OutputPorts { get; set; }
    }
}