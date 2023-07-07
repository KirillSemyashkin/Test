using RailRoadApp.Core.Models;
using RailRoadApp.Core.Services.Graphs;
using RailRoadApp.ViewModels;
using System.Drawing;
using System.Linq;

namespace RailRoadApp.Services;

internal class VMBuilder : IVMBuilder
{
    private readonly IGraphFactory<Point> factory;

    public VMBuilder(IGraphFactory<Point> factory) {
        this.factory = factory;
    }

    public StationViewModel BuildViewModel(StationModel station) {
        var result = new StationViewModel { StationName = station.Name };
        result.Graph = factory.BuildGraphFromModels(station.Parts);
        result.Parts = result.Graph.Edges.Select(e => new TrackPartViewModel { Model = e }).ToList();

        foreach (var track in station.Tracks) {
            var trackVm = new TrackViewModel {
                Model = track,
                Parts = result.Parts.Where(p => track.TrackParts.Contains(p.Id)).ToList()
            };
            result.Tracks.Add(trackVm);
        }

        foreach (var park in station.Parks) {
            var parkVm = new ParkViewModel {
                Model = park,
                Tracks = result.Tracks.Where(t => park.TrackIds.Contains(t.Id)).ToList()
            };
            result.Parks.Add(parkVm);
        }

        return result;
    }
}
