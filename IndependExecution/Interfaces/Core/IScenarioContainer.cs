using IndependExecution.Implementention.Core;

namespace IndependExecution.Interfaces.Core
{
    /// <summary>
    /// Contains all open scenarios
    /// </summary>
    public interface IScenarioContainer
    {
        /// <summary>
        /// Retrieves an existing scenario
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns></returns>
        DataFlow GetDataFlow(IScenario scenario);
        
        /// <summary>
        /// Creates a new scenario
        /// </summary>
        /// <param name="scenario"></param>
        void CreateDataFlow(IScenario scenario);
    }
}
