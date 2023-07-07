using RailRoadApp.Core.Models;
using RailRoadApp.ViewModels;

namespace RailRoadApp.Services;

internal interface IVMBuilder
{
    StationViewModel BuildViewModel(StationModel station);
}
