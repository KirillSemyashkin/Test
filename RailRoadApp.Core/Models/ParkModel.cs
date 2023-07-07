namespace RailRoadApp.Core.Models;

public class ParkModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<long> TrackIds { get; set; } = new List<long>();
}
