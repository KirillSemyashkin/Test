using RailRoadApp.Core.Models;

namespace RailRoadApp.Core.Services;

public interface IModelProvider
{
    public List<StationModel> GetModels();
}
