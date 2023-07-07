using RailRoadApp.Core.Models;
using RailRoadApp.Core.Services;
using RailRoadApp.Core.Services.Graphs;
using System.Drawing;

namespace RailRoadApp.Services.Graphs;

public class GraphFactrory : IGraphFactory<Point>
{
    public WeightedGraph<Point> BuildGraphFromModels(List<TrackPartModel> models) {
        List<IWeightedVertex<Point>> vertices = new();
        List<IWeightedEdge<Point>> edges = new();

        foreach (var model in models) {
            var start = vertices.RetrieveOrCreateAndStore(model.Start);
            var end = vertices.RetrieveOrCreateAndStore(model.End);
            var edge = new TrackPartNavigationAdapter(model, end, start);
            edges.Add(edge);
            start.AddNeighbor(end);
            start.AddEdge(edge);
            end.AddNeighbor(start);
            end.AddEdge(edge);
        }

        return new WeightedGraph<Point>(vertices, edges);
    }
}
