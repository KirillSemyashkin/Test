using RailRoadApp.Core.Models;

namespace RailRoadApp.Core.Services.Graphs;

public interface IGraphFactory<Point>
{
    public WeightedGraph<Point> BuildGraphFromModels(List<TrackPartModel> models);
}
