using System.Drawing;

namespace RailRoadApp.Core.Services.Graphs;

public static class GraphExtensions
{
    public static IWeightedVertex<Point> GetNeighbour(this TrackPartNavigationAdapter edge, IWeightedVertex<Point> vertex) {
        return edge.Start.Equals(vertex) ? edge.End : edge.Start;
    }
    public static IWeightedVertex<Point> RetrieveOrCreateAndStore(this List<IWeightedVertex<Point>> vertices, Point point) {
        var vertex = vertices.FirstOrDefault(v => v.Value.Equals(point));
        if (vertex == null) {
            vertex = new Waypoint(point);
            vertices.Add(vertex);
        }
        return vertex;
    }
}
