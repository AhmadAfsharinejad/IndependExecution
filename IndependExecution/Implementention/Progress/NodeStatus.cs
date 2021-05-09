using IndependExecution.Dto.Link;

namespace IndependExecution.Implementention.Progress
{
    public class NodeStatus
    {
        public NodeStatus(string id, string typeId)
        {
            Id = id;
            TypeId = typeId;
        }

        public string Id { get; }
        public string TypeId { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public IInputPort InputPorts { get; set; }
        public IOutputPort OutputPorts { get; set; }

        public override string ToString()
        {
            return $"id:{Id}, typeId:{TypeId}, State:{State}, Name:{Name}";
        }
    }
}
