using System.Drawing;

namespace RailRoadApp.Core.Services.Graphs;

public class Waypoint : IWeightedVertex<Point>
{
    public Waypoint(Point value) {
        Value = value;
    }

    public List<IWeightedVertex<Point>> Neighbors { get; } = new List<IWeightedVertex<Point>>();

    public List<IWeightedEdge<Point>> Edges { get; } = new List<IWeightedEdge<Point>>();

    public Point Value { get; }

    public int NeighborsCount => Neighbors.Count;

    public bool IsVisited { get; set; }

    public double AccamulatedWeight { get; set; }

    public void AddEdge(IWeightedEdge<Point> edge) => Edges.Add(edge);

    public void AddNeighbor(IWeightedVertex<Point> vertex) => Neighbors.Add(vertex);
}
