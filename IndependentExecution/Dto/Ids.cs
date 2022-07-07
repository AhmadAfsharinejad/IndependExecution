using StronglyTypedIds;

[assembly:StronglyTypedIdDefaults(
    backingType: StronglyTypedIdBackingType.String)]

namespace IndependentExecution.Dto
{
    [StronglyTypedId]
    public partial struct LinkId
    {
    }

    [StronglyTypedId]
    public partial struct PluginId
    {
    }

    [StronglyTypedId]
    public partial struct PluginTypeId
    {
    }

    [StronglyTypedId]
    public partial struct PortId
    {
    }

    [StronglyTypedId]
    public partial struct ColumnSchemaId
    {
    }

    [StronglyTypedId]
    public partial struct TableSchemaId
    {
    }

    [StronglyTypedId]
    public partial struct RunTimeParametersId
    {
    }

    [StronglyTypedId]
    public partial struct ProcessorId
    {
    }

    [StronglyTypedId]
    public partial struct ExecutorId
    {
    }

    [StronglyTypedId]
    public partial struct ScenarioId
    {
    }
}