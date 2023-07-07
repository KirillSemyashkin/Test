namespace RailRoadApp.Core.Services.Graphs;

public interface IWeightedEdge<TValue>
{
    public long Id { get; }
    public string Name { get; }
    public double Weight { get; }
    public IWeightedVertex<TValue> Start { get; }
    public IWeightedVertex<TValue> End { get; }
    public IWeightedVertex<TValue> GetNeighbour(IWeightedVertex<TValue> value);
}
