using System.Drawing;
using System.Text;

namespace RailRoadApp.Core.Services.Polygons;

public class NotationProvider
{
    public string ReturnPolygonNotation(List<Point> points) {
        var hull = GetConvexHull(points);
        var result = new StringBuilder();
        Point point;
        while (hull.Count != 0) {
            point = hull.Pop();
            result.Append($"{point.X},{point.Y} ");
        }
        return result.ToString();
    }

    private bool IsLeftOriented(Point a, Point b, Point c) {
        return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X) > 0;
    }

    private Stack<Point> GetConvexHull(List<Point> points) {
        var hull = new Stack<Point>();
        if (points.Count() <= 3) {
            points.ForEach(p => hull.Push(p));
            return hull;
        }
        points.Sort((a, b) =>
            a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

        Point hullPoint = points[0];

        Point candidate;
        do {
            hull.Push(hullPoint);
            candidate = points[0];

            for (int i = 1; i < points.Count; i++) {
                if ((hullPoint == candidate)
                    || (IsLeftOriented(hullPoint, candidate, points[i]))) {
                    candidate = points[i];
                }
            }

            hullPoint = candidate;

        }
        while (candidate != hull.Last());

        return hull;
    }
}
