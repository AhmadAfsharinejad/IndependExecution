using System.Collections.Generic;

namespace IndependentExecution.Dto
{
    public record InputTableSchema
    {
        public InputTableSchema(List<ColumnSchema> columns, string id)
        {
            Columns = columns;
            Id = id;
        }

        private string Id { get; init; }
        List<ColumnSchema> Columns { get; }
    }
}
