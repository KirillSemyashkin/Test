using RailRoadApp.Core.Services.Graphs;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RailRoadApp.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RailRoadApp.ViewModels;

public class TrackViewModel : ObservableRecipient
{
    public TrackModel Model { get; set; } = new();
    public string Name => Model.Name;
    public long Id => Model.Id;
    public List<TrackPartViewModel> Parts { get; set; } = new List<TrackPartViewModel>();
    public IEnumerable<IWeightedVertex<Point>> Waypoints
        => Parts.Select(p => p.Start)
        .Union(Parts.Select(p => p.End));

}
