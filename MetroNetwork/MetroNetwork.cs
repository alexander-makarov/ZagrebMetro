using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ConnectedComponents;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.Search;
using QuickGraph.Algorithms.Services;
using QuickGraph.Data;

namespace MetroNetwork
{
    public class MetroNetworkGraph : IMetroNetworkGraph
    {
        private readonly BidirectionalGraph<string, Edge<string>> _graph = new BidirectionalGraph<string, Edge<string>>();
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
                // if wanna look for shortest path from a vertex back to the same vertex
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


        /// <summary>
        /// Find all possible trips between two stations including round trips (cycles) with specified number of stops
        /// <remarks>
        /// https://en.wikipedia.org/wiki/K_shortest_path_routing
        /// http://citeseer.ist.psu.edu/viewdoc/download;jsessionid=7BB56B2ABC7C9113C121413A62AF3974?doi=10.1.1.30.3705&rep=rep1&type=pdf
        /// http://people.csail.mit.edu/minilek/yen_kth_shortest.pdf
        /// https://github.com/yan-qi/k-shortest-paths-java-version
        /// </remarks>
        /// </summary>
        /// <param name="start">vertice to start recursibe traversion with</param>
        /// <param name="end">end destination vertice, the one that trip(path) should be finishing on</param>
        /// <param name="exactStopsInBetween">number of stops between (number of vertices)</param>
        /// <returns></returns>
        public IEnumerable<string> GetAllPossibleTripsBetweenStations(string start, string end, int exactStopsInBetween)
        {
            var result = new List<string>();
            
            var allRoutes = GetStationRoutesFromRecursive(start, "not-existent-root-station-to-allow-loops", 0, exactStopsInBetween);
            var onlyCycles = allRoutes.Where(rt =>
                rt.Last() == start &&
                rt.First() == end &&
                rt.Count > 1).ToList();
            foreach (var cycle in onlyCycles)
            {
                cycle.Reverse();
                var onlyStops = cycle.GetRange(1, cycle.Count - 2);
                var sb = new StringBuilder();
                onlyStops.ForEach(s => sb.Append(s).Append("-"));
                var str = sb.ToString().TrimEnd('-');
                result.Add(str);
            }

            #region RankedShortestPathHoffmanPavley from quickgraph, but it finds only loopless kth shortest pathes, whereas we need loops too
            //var edgeCost = new Func<Edge<string>, double>(e => 1); //AlgorithmExtensions.GetIndexer(_costs);
            //var hoffmanPavley = _graph.RankedShortestPathHoffmanPavley(edgeCost, start, end, 4 + 2);
            //foreach (IEnumerable<Edge<string>> path in hoffmanPavley)
            //{
            //    var sb = new StringBuilder();
            //    path.ToList().GetRange(0, cycle.Count - 1).ForEach(s => sb.Append(s.Target).Append("-"));
            //    var str = sb.ToString().TrimEnd('-');
            //    result.Add(str);
            //}
            #endregion 

            return result;
        }


        /// <summary>
        /// Recursive traversal from root station for 3 station next depth
        /// in order to find any round trips (i.e. graph cycles)
        /// 
        /// <remarks>Not very effecient solution, works okay for metro network 
        /// because we have predefined 3 stops depth restriction 
        /// (thus only looks for cycles with length not more than five)
        /// and we assumed metro network as a sparse graph 
        /// (i.e. not expecting every station have edge to every other station definetly). 
        /// Comnplexity is about O(E^3) where E is average amount of out-edges per vertex in a graph.
        /// 
        /// for any performance improvement one might consider:
        /// 1. Strongly connected components and cycles are synonymous (but not exactly the same).
        /// https://en.wikipedia.org/wiki/Tarjan's_strongly_connected_components_algorithm
        /// http://www.ics.uci.edu/~eppstein/161/960220.html  
        /// http://en.wikipedia.org/wiki/Path-based_strong_component_algorithm
        /// Donald B. Johnson algorithm for finding cycles improving Tarjans: http://www.cs.tufts.edu/comp/150GA/homeworks/hw1/Johnson%2075.PDF  
        /// 
        /// 2. Performing DFS with tracking of frontends and backends 
        /// http://en.wikipedia.org/wiki/Depth-first_search#Pseudocode
        /// 
        /// more:
        /// http://stackoverflow.com/questions/546655/finding-all-cycles-in-graph
        /// http://mathoverflow.net/questions/16393/finding-a-cycle-of-fixed-length
        /// http://epubs.siam.org/doi/abs/10.1137/0205007 On Algorithms for Enumerating All Circuits of a Graph
        /// </remarks>
        /// </summary>
        /// <param name="station"></param>
        /// <returns>list of all round trips (cycles no longer than 5 stations) </returns>
        public IEnumerable<string> GetRoundTripsForStation(string station)
        {
            var result = new List<string>();
            var allRoutes = GetStationRoutesFromRecursive(station, station, 0, 3);
            var onlyCycles = allRoutes.Where(rt => 
                rt.Last() == station &&
                rt.First() == station &&
                rt.Count > 1).ToList();
            foreach (var cycle in onlyCycles)
            {
                cycle.Reverse();
                var sb = new StringBuilder();
                cycle.ForEach(s => sb.Append(s).Append("-"));
                var str = sb.ToString().TrimEnd('-');
                result.Add(str);
            }
            return result;
        }
        
        /// <summary>
        /// Basically primitive form of depth-first traversal (with no colors applying)
        /// </summary>
        /// <param name="station">station vertex to start with</param>
        /// <param name="endStationToStopRouting">station vertex on which to stop traversion</param>
        /// <param name="depth">current recursive depth</param>
        /// <returns>list of routes (route is list of edges on graph)</returns>
        private List<List<string>> GetStationRoutesFromRecursive(string station, string endStationToStopRouting, int depth = 0, int maxDepthOfRecursiveTraversal = 3)
        {
            if (depth++ == maxDepthOfRecursiveTraversal) // here restrict for a maximum of 3 stops for a round trip / cycle basically
                return new List<List<string>> { new List<string> { station } }; // stop recursive traversion if too deep

            var result = new List<List<string>>();
            IEnumerable<Edge<string>> outEdges;
            if(_graph.TryGetOutEdges(station, out outEdges))
            {
                foreach (var edge in outEdges)
                {
                    if (edge.Target == endStationToStopRouting) // if found a cycle, i.e. round trip to root station:
                    {
                        result.Add(new List<string> { edge.Target, station }); 
                        continue; // no recursive call needed
                    }

                    var routes = GetStationRoutesFromRecursive(edge.Target, endStationToStopRouting, depth, maxDepthOfRecursiveTraversal);
                    routes.ForEach(rt => rt.Add(station));
                    result.AddRange(routes);
                }
            }

            return result;
        }

        public double GetAdjacentPathDistanceBetweenStations(string from, string to)
        {
            Edge<string> routeFromTo;
            _graph.TryGetEdge(from, to, out routeFromTo); // i believe that works fine under the hood, one might check later

            if (routeFromTo != null)
            {
                return _costs[routeFromTo];
            }

            return -1;
        }
    }
}