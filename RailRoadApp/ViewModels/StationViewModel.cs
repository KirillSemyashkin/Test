using CommunityToolkit.Mvvm.ComponentModel;
using RailRoadApp.Core.Services;
using RailRoadApp.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace RailRoadApp.ViewModels;

public partial class StationViewModel : ObservableRecipient
{
    public string StationName { get; set; } = string.Empty;
    public WeightedGraph<Point> Graph { get; set; }

    public List<TrackPartViewModel> Parts { get; set; } = new();

    public List<TrackViewModel> Tracks { get; set; } = new();
    public List<ParkViewModel> Parks { get; set; } = new();

    public void SetSelection(ParkViewModel park) {
        Parts.ForEach(p => p.State = ETrackState.Default);
        foreach (var part in park.Parts) {
            part.State = ETrackState.Selected;
        }
    }

    [ObservableProperty]
    private string parkNotation = string.Empty;
    [ObservableProperty]
    private Color polygonColor = new();
}
