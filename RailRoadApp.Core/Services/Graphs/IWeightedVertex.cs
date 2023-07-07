namespace RailRoadApp.Core.Services.Graphs;

public interface IWeightedVertex<TValue>
{
    public List<IWeightedVertex<TValue>> Neighbors { get; }
    public List<IWeightedEdge<TValue>> Edges { get; }
    public TValue Value { get; }
    public int NeighborsCount { get; }
    public bool IsVisited { get; set; }
    public double AccamulatedWeight { get; set; }
    public void AddNeighbor(IWeightedVertex<TValue> vertex);
    public void AddEdge(IWeightedEdge<TValue> edge);
}
