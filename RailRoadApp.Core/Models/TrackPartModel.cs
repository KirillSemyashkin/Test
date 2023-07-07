using System.Drawing;

namespace RailRoadApp.Core.Models;

public class TrackPartModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Point Start { get; set; }
    public Point End { get; set; }
    public float Weight { get; set; }
}
