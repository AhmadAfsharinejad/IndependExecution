namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlow :
        IExecute,
        IConfig,
        IGraph
    {
        //mogheye load
        object GetDataFlow();
        void Load(string id);
    }
}
