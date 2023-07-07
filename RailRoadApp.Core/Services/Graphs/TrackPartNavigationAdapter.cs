using RailRoadApp.Core.Models;
using System.Drawing;

namespace RailRoadApp.Core.Services.Graphs;

public class TrackPartNavigationAdapter : IWeightedEdge<Point>
{
    private readonly TrackPartModel model;

    public TrackPartNavigationAdapter(
        TrackPartModel model,
        IWeightedVertex<Point> start,
        IWeightedVertex<Point> end) {
        this.model = model;
        Start = start;
        End = end;
    }

    public long Id => model.Id;
    public string Name => model.Name;
    public double Weight => model.Weight;

    public IWeightedVertex<Point> Start { get; }

    public IWeightedVertex<Point> End { get; }

    public IWeightedVertex<Point> GetNeighbour(IWeightedVertex<Point> value)
        => value.Value == Start.Value ? End : Start;
}