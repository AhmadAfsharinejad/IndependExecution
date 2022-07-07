#pragma warning disable CS8618
namespace IndependentExecution.Dto;

public record RunTimeParametersResponse
{
    public RunTimeParametersId Id { get; init; } 
    public string Name { get; init; } 
    public string Type { get; init; } 
}