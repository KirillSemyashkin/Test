using RailRoadApp.Core.Models;
using RailRoadApp.Core.Services.Graphs;

namespace RailRoadApp.Core.Services;
public class WeightedGraph<TValue>
{
    public WeightedGraph(
        List<IWeightedVertex<TValue>> vertices,
        List<IWeightedEdge<TValue>> edges) {
        Vertices = vertices;
        Edges = edges;
    }

    public List<IWeightedVertex<TValue>> Vertices { get; }
    public List<IWeightedEdge<TValue>> Edges { get; }

}