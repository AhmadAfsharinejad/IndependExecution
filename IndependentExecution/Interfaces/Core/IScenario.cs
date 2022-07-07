using IndependentExecution.Dto;

namespace IndependentExecution.Interfaces.Core
{
    public interface IScenario :
        IExecutor,
        IScenarioConfigurable,
        IGraph
    {
        /// <summary>
        /// 1- از طریق کلاینت دیگری باز شود
        /// </summary>
        /// <returns></returns>
        ScenarioStatus GetScenarioStatus();
        
        /// <summary>
        /// 1- اولین بار که از طریق لیست باز میشود
        /// </summary>
        /// <returns></returns>
        ScenarioStatus Load();
    }
}
