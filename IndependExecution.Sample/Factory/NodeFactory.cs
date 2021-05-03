using IndependExecution.Model;

namespace IndependExecution.Sample.Factory
{
    public class NodeFactory
    {
        public static Node Create(string id, string typeId)
        {
            return new Node(id, typeId)
            {

            };
        }
    }
}
