namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlow<TNode, TLink, TProgress, TNotify> :
        IEexute<TNode, TLink, TProgress>,
        IConfig<TNode, TNotify>,
        IGraph<TNode, TLink, TNotify>
        where TNode : INode
        where TLink : ILink<TNode>
    {
        //mogheye load
        object GetDataFlow();
        void Load(string id);
    }
}
