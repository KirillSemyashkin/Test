using RailRoadApp.Core.Models;

namespace RailRoadApp.Core.Services;

public class ModelProvider : IModelProvider
{
    public List<StationModel> GetModels() => new() { StationModel.DummyA };
}
