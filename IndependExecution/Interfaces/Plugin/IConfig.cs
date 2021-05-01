using System.Collections.Generic;

namespace IndependExecution.Interfaces.Plugin
{
    public interface IConfig<IOutputChangeNotifier>
    {
        IOutputChangeNotifier<IOutputChangeNotifier> Notifier { get; }
        void ChangeConfig<TConfig>(IEnumerable<object> inputTables, TConfig config);
        TConfig GetConfig<TConfig>();
    }
}
