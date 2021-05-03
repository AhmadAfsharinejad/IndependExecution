namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlow :
        IEexute,
        IConfig,
        IGraph
    {
        //mogheye load
        object GetDataFlow();
        void Load(string id);
    }
}
