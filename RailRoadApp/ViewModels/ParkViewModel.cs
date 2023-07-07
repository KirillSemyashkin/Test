using CommunityToolkit.Mvvm.ComponentModel;
using RailRoadApp.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RailRoadApp.ViewModels;

public partial class ParkViewModel : ObservableRecipient
{
    public ParkModel Model { get; set; } = new();
    public int Id => Model?.Id ?? 0;
    public string Name => Model?.Name ?? string.Empty;
    public List<TrackViewModel> Tracks { get; set; } = new List<TrackViewModel>();
    public IEnumerable<TrackPartViewModel> Parts => Tracks.SelectMany(t => t.Parts);
}
