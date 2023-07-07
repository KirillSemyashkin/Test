namespace RailRoadApp.Core.Models;

public class TrackModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<long> TrackParts { get; set; } = new();
}
