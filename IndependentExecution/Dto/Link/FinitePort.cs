namespace IndependentExecution.Dto.Link
{
    public record FinitePort : IInputPort
    {
        public int MaxPort { get; set; }
    }
}
