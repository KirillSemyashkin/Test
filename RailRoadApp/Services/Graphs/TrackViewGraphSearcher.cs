using RailRoadApp.Core.Services;
using RailRoadApp.Core.Services.Graphs;
using RailRoadApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Data;
using RailRoadApp.Core.Models;
using RailRoadApp.Core.Services.Exceptions;

namespace RailRoadApp.Services.Graphs;

internal class TrackViewGraphSearcher : ITrackViewGraphSearcher
{
    public List<long> FindShortest(TrackViewModel first, TrackViewModel second, WeightedGraph<Point> graph) {
        var verteces = PerformSearch(first, second, graph);
        return ConstructTrack(verteces);
    }

    public List<long> FindShortest(TrackPartViewModel first, TrackPartViewModel second, WeightedGraph<Point> graph) {
        TrackViewModel Make(TrackPartViewModel tp) {
            var tvm = new TrackViewModel();
            tvm.Parts.Add(tp);
            return tvm;
        }

        return FindShortest(Make(first), Make(second), graph);
    }

    private List<IWeightedVertex<Point>> PerformSearch(TrackViewModel first, TrackViewModel second, WeightedGraph<Point> graph) {
        var parentMap = new Dictionary<IWeightedVertex<Point>, IWeightedVertex<Point>>();
        var priorityQueue = new PriorityQueue<IWeightedVertex<Point>, double>();

        InitializeCosts(first, graph.Vertices);
        foreach (IWeightedVertex<Point> v in first.Waypoints) {
            priorityQueue.Enqueue(v, v.AccamulatedWeight);
        }
        double totalCost = double.MaxValue;
        IWeightedVertex<Point> current;
        IWeightedVertex<Point> final = default;

        while (priorityQueue.Count > 0) {
            current = priorityQueue.Dequeue();

            if (!current.IsVisited) {
                current.IsVisited = true;

                if (current.AccamulatedWeight > totalCost) {
                    break;
                }

                if (second.Waypoints.Contains(current)) {
                    if (current.AccamulatedWeight < totalCost) {
                        totalCost = current.AccamulatedWeight;
                        final = current;
                    }
                    break;
                }

                foreach (IWeightedEdge<Point> edge in current.Edges) {
                    var neighbor = edge.GetNeighbour(current);

                    var newCost = current.AccamulatedWeight + edge.Weight;
                    var neighborCost = neighbor.AccamulatedWeight;

                    if (newCost < neighborCost) {
                        neighbor.AccamulatedWeight = newCost;
                        parentMap.Add(neighbor, current);
                        double priority = newCost;
                        priorityQueue.Enqueue(neighbor, priority);
                    }
                }
            }
        }
        return ReconstructWaypoints(parentMap, final);
    }

    private void InitializeCosts(TrackViewModel first, List<IWeightedVertex<Point>> vertices) {
        foreach (IWeightedVertex<Point> vertex in vertices) {
            vertex.AccamulatedWeight = double.MaxValue;
            vertex.IsVisited = false;
        }
        foreach (IWeightedVertex<Point> vertex in first.Waypoints) {
            vertex.AccamulatedWeight = 0;
            vertex.IsVisited = false;
        }
    }

    private List<IWeightedVertex<Point>> ReconstructWaypoints(
        Dictionary<IWeightedVertex<Point>, IWeightedVertex<Point>> parentMap,
        IWeightedVertex<Point> end) {
        var result = new List<IWeightedVertex<Point>>();
        if (end is null) {
            throw new PartsNotConnectedException();
        }

        if (parentMap.Count <= 2) {
            return result;
        }

        var current = end;

        while (true) {
            result.Add(current);
            current = parentMap[current];
            if (current.AccamulatedWeight == 0) {
                break;
            }
        }
        result.Add(current);
        result.Reverse();
        return result;
    }

    private List<long> ConstructTrack(List<IWeightedVertex<Point>> vertices) {
        var result = new List<long>();
        for (int i = 1; i < vertices.Count; i++) {
            var trackPartId = vertices[i - 1].Edges.First(e => e.GetNeighbour(vertices[i - 1]) == vertices[i]).Id;
            result.Add(trackPartId);
        }
        return result;
    }
}
