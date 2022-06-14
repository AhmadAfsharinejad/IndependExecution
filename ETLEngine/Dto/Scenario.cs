using IndependExecution.Interfaces.Core;

namespace ETLEngine.Dto
{
    public class Scenario : IScenario
    {
        public Scenario(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
