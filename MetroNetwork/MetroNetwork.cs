using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Services;
using QuickGraph.Data;

namespace MetroNetwork
{
    public class MetroNetworkGraph : IMetroNetworkGraph
    {
        private readonly AdjacencyGraph<string, Edge<string>> _graph = new AdjacencyGraph<string, Edge<string>>();
        private readonly Dictionary<Edge<string>, double> _costs = new Dictionary<Edge<string>, double>();
        public void ReadFromString(string metroNetworkGraphStr)
        {
            if(String.IsNullOrWhiteSpace(metroNetworkGraphStr))
                throw new ArgumentException("Metro network string either null, empty or consists only of whitespaces", "metroNetworkGraphStr");

            try
            {
                var edges = metroNetworkGraphStr.Split(',').Select(s => s.Trim());
                foreach (var edgeStr in edges)
                {
                    var stationPairAndDistance = edgeStr.Split(':');
                    var stationPair = stationPairAndDistance[0].Split('-');
                    var station1 = stationPair[0];
                    var station2 = stationPair[1];
                    var distance = Int32.Parse(stationPairAndDistance[1]);

                    if (!_graph.ContainsVertex(station1))
                    {
                        _graph.AddVertex(station1);
                    }
                    if (!_graph.ContainsVertex(station2))
                    {
                        _graph.AddVertex(station2);
                    }

                    var edge = new Edge<string>(station1, station2);
                    if (!_graph.ContainsEdge(edge))
                    {
                        _graph.AddEdge(edge);
                        _costs.Add(edge, distance);
                    }
                }
            }
            catch (Exception exc)
            {
                throw new FormatException("Can't read a metro networkgraph - string is in incorrect format", exc);
            }
            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var edgeAndCost in _costs)
            {
                var stationFrom = edgeAndCost.Key.Source;
                var stationTo = edgeAndCost.Key.Target;
                var distance = edgeAndCost.Value;
                sb.AppendFormat("From {0} to {1} -> {2}", stationFrom, stationTo, distance).AppendLine();
            }

            return sb.ToString();
        }

        public double GetPathDistanceBetweenStations(string from, string to)
        {
            if (from == to)
            {
                // if wanna llok for shortest path from a vertex back to the same vertex
                // i.e. shortest cycle included a given vertex
                // use the Floyd-Warshall algorithm O(V^3)
                var distance = 0.0;
                if (ShortestCycleIncludedAGivenVertex.TryGetDistanceFloydWarshall(_graph, _costs, from, out distance))
                {
                    return distance;
                }

            }
            else // otherwise use Dijkstra
            {
                var edgeCost = AlgorithmExtensions.GetIndexer(_costs);
                var tryGetPath = _graph.ShortestPathsDijkstra(edgeCost, from);
                IEnumerable<Edge<string>> path;
                var isPathExists = tryGetPath(to, out path);
                if (isPathExists)
                {
                    var distance = path.Sum(edgeCost);
                    return distance;
                }
            }

            return -1;
        }

        public double GetAdjacentPathDistanceBetweenStations(string from, string to)
        {
            Edge<string> routeFromTo;
            _graph.TryGetEdge(from, to, out routeFromTo); // i believe that works fine under the hood, one might check later
            // O(N) have to check every edge, not very efficient
            //var routeFromTo = _graph.Edges.SingleOrDefault(edge => (edge.Source == from && edge.Target == to));
            //var vFrom = _graph.Vertices.FirstOrDefault(v => v == from);

            if (routeFromTo != null)
            {
                return _costs[routeFromTo];
            }

            return -1;
        }
    }
}