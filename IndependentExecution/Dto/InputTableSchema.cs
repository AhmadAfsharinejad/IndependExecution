using System.Collections.Generic;
#pragma warning disable CS8618

namespace IndependentExecution.Dto
{
    public record InputTableSchema
    {
        private TableSchemaId Id { get; init; }
        private List<ColumnSchema> Columns { get; set; }
    }
}
