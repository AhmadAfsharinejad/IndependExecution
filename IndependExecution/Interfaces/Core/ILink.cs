namespace IndependExecution.Interfaces.Core
{
    public interface ILink
    {
        INode Source { get; }
        INode Target { get; }
        string Id { get; }
        string Id2 { get; }
    }
}
