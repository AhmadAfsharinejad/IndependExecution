namespace IndependExecution.Interfaces.Core
{
    public interface ILink<TNode>
    {
        TNode Source { get; }
        TNode Target { get; }
    }
}
