namespace IndependExecution.Interfaces.Core
{
    public interface IDataFlow<TProgress, TNotify> :
        IEexute<TProgress>,
        IConfig<TNotify>,
        IGraph<TNotify>
    {
        //mogheye load
        object GetDataFlow();
        void Load(string id);
    }
}
