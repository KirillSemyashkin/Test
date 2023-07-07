using RailRoadApp.Core.Services;
using RailRoadApp.Core.Services.Graphs;
using RailRoadApp.ViewModels;
using System.Collections.Generic;
using System.Drawing;

namespace RailRoadApp.Services.Graphs;

internal interface ITrackViewGraphSearcher
{
    public List<long> FindShortest(TrackViewModel first, TrackViewModel second, WeightedGraph<Point> graph);
    public List<long> FindShortest(TrackPartViewModel first, TrackPartViewModel second, WeightedGraph<Point> graph);

}
