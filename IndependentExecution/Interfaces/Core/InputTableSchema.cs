using System.Collections.Generic;

namespace IndependentExecution.Interfaces.Core
{
    public record InputTableSchema
    {
        public InputTableSchema(List<IColumn> columns, string id)
        {
            Columns = columns;
            Id = id;
        }
        
        string Id { get; }
        List<IColumn> Columns { get; }
    }
}
