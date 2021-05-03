using System.Collections.Generic;

namespace IndependExecution.Interfaces.Core
{
    public interface ITable
    {
        string Id { get; }
        List<IColumn> Columns { get; }
    }
}
