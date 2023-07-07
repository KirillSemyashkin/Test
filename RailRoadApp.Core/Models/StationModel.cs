using System.Drawing;

namespace RailRoadApp.Core.Models;

public class StationModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<TrackPartModel> Parts { get; set; } = new();
    public List<TrackModel> Tracks { get; set; } = new();
    public List<ParkModel> Parks { get; set; } = new();

    public static StationModel DummyA = new() {
        Id = 1,
        Name = "ParkTest_A",
        Parts = new List<TrackPartModel>
        {
            new TrackPartModel { Id = 1, Name = "AB", Start = new Point(40, 50), End = new Point(50, 60), Weight = 6 },
            new TrackPartModel { Id = 2, Name = "BC", Start = new Point(50, 60), End = new Point(60, 80), Weight = 4 },
            new TrackPartModel { Id = 3, Name = "BD", Start = new Point(50, 60), End = new Point(70, 40), Weight = 7 },
            new TrackPartModel { Id = 4, Name = "CE", Start = new Point(60, 80), End = new Point(80, 80), Weight = 4 },
            new TrackPartModel { Id = 5, Name = "DF", Start = new Point(70, 40), End = new Point(80, 40), Weight = 3 },
            new TrackPartModel { Id = 6, Name = "FG", Start = new Point(80, 40), End = new Point(100, 60), Weight = 5 },
            new TrackPartModel { Id = 7, Name = "GH", Start = new Point(100, 60), End = new Point(120, 50), Weight = 4 },
            new TrackPartModel { Id = 8, Name = "EH", Start = new Point(80, 80), End = new Point(120, 50), Weight = 8 },
            new TrackPartModel { Id = 9, Name = "HJ", Start = new Point(120, 50), End = new Point(150, 60), Weight = 6 },
            new TrackPartModel { Id = 10, Name = "HI", Start = new Point(120, 50), End = new Point(150, 90), Weight = 10 },
            new TrackPartModel { Id = 11, Name = "IK", Start = new Point(150, 90), End = new Point(170, 90), Weight = 6 }
        },
        Tracks = new List<TrackModel>
        {
            new TrackModel()
            {
                Id = 1,
                Name = "C-E-H",
                TrackParts = { 4, 8 }
            },
            new TrackModel()
            {
                Id = 2,
                Name = "D-F-G",
                TrackParts = { 5, 6 }
            },
        },
        Parks = new List<ParkModel>
        {
            new ParkModel() { Id = 1, Name = "TestPark_1", TrackIds = { 1, 2} }
        }
    };
}
