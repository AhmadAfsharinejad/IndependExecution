#pragma warning disable CS8618
namespace IndependentExecution.Dto;

public record Port
{
    public  PortId? Id { get; set; }
    public  string? Name { get; set; }
}