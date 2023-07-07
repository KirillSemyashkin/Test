using CommunityToolkit.Mvvm.ComponentModel;
using RailRoadApp.Core.Services.Graphs;
using RailRoadApp.Enums;
using System.Drawing;

namespace RailRoadApp.ViewModels;

public partial class TrackPartViewModel : ObservableRecipient
{
    private ETrackState state;
    public IWeightedEdge<Point> Model { get; set; }

    public double Weight => Model?.Weight ?? 0;

    public IWeightedVertex<Point> Start => Model.Start;

    public IWeightedVertex<Point> End => Model.End;

    public string Name => Model.Name;

    public long Id => Model.Id;

    public ETrackState State {
        get => state;
        set {
            state = value;
            switch (state) {
                case ETrackState.Selected:
                    Color = Color.Red;
                    break;
                case ETrackState.Highlighted:
                    Color = Color.Green;
                    break;
                default:
                    Color = Color.Black;
                    break;
            }
            OnPropertyChanged(nameof(Color));
        }
    }

    public Color Color { get; set; } = Color.Black;

}
