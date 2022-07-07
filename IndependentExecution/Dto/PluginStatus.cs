using System.Collections.Generic;

#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    //TODO esme behtar , farghesh ba PluginDetails malom she
    public record PluginStatus
    {
        public PluginStatus(string id)
        {
            Id = id;
        }

        public string Id { get; init;}
        //TODO lazeme
        public string State { get; set; }
        public List<Port> InputPorts { get; set; }
        public List<Port> OutputPorts { get; set; }

        public override string ToString()
        {
            return $"id:{Id}, State:{State}";
        }
    }
}
