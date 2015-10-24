﻿using System;
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

        public IEnumerable<string> GetRoutingTripsForStation(string station)
        {
            var result = new List<string>();
            var allRoutes = GetStationRoutesFromRecursive(station, 0, station);
            var onlyCycles = allRoutes.Where(rt => 
                rt.Last() == station &&
                rt.First() == station &&
                rt.Count > 1).ToList();
            foreach (var cycle in onlyCycles)
            {
                cycle.Reverse();
                var str = "";
                cycle.ForEach(s => str += s + "-");
                str = str.TrimEnd('-');
                result.Add(str);
            }
            return result;
        }

        private List<List<string>> GetStationRoutesFromRecursive(string station, int depth, string rootStation)
        {
            if (depth++ == 3) // here restrict for only 3 stops in a cycle basically
                return new List<List<string>>() { new List<string> { station } }; // stop recursive traversion if too deep

            var result = new List<List<string>>();
            IEnumerable<Edge<string>> outEdges;
            if(_graph.TryGetOutEdges(station, out outEdges))
            {
                foreach (var edge in outEdges)
                {
                    if (edge.Target == rootStation) // if found a cycle, i.e. round trip to root station:
                    {
                        result.Add(new List<string> { edge.Target, station }); 
                        continue; // no recursive call needed
                    }

                    var routes = GetStationRoutesFromRecursive(edge.Target, depth, rootStation);
                    //var extended = routes.Select(route => new List<string>(route)).ToList();
                    routes.ForEach(rt => rt.Add(station));
                    result.AddRange(routes);
                }
            }

            return result;
        }

        //public IEnumerable<string> GetRoutingTripsForStation(string station)
        //{
        //    // create algorithm
        //    var dfs = new DepthFirstSearchAlgorithm<string, Edge<string>>(_graph);
        //    dfs.SetRootVertex(station);
        //    var lstttt = new List<List<string>>();

        //    //for (int i = 0; i < 3; i++)
        //    {
        //        //dfs. = i;

        //        var observer = new VertexPredecessorRecorderObserver<string, Edge<string>>();
        //        observer.VertexPredecessors.Add(station, null);
        //        List<string> visitedVErtices = new List<string>();
        //        using (observer.Attach(dfs)) // attach, detach to dfs events
        //        {
        //            dfs.ExamineEdge += e =>
        //            {
        //                var v = e.Target;
        //                visitedVErtices.Add(v);
        //                if (v != station)
        //                {
        //                    var l = _graph.OutEdges(v);
        //                    if (l.Any(adj => lstttt.Any(innerL => innerL.Contains(adj.Target))))
        //                    {
        //                        var connectedToCyclic = l.Where((adj => lstttt.Any(innerL => innerL.Contains(adj.Target))));
        //                        foreach (var frontEnd in connectedToCyclic)
        //                        {
        //                            var inner = new List<string>();

        //                            string end = frontEnd.Target;
        //                            var cycles = lstttt.Where(innerL => innerL.Contains(end));
        //                            foreach (var cycle in cycles)
        //                            {
        //                                var c = new List<string>(cycle);
        //                                c.Reverse();
        //                                foreach (var vertex in c)
        //                                {
        //                                    inner.Add(vertex);
        //                                    if (vertex == end)
        //                                        break;
        //                                }
        //                                break;
        //                            }

        //                            inner.Add(e.Target);
        //                            if (e.Source != station)
        //                            {
        //                                //inner.Add(e.Source);

        //                                var pred = observer.VertexPredecessors[e.Source];
        //                                while (pred != null)
        //                                {
        //                                    inner.Add(pred.Target);
        //                                    if (observer.VertexPredecessors.ContainsKey(pred.Source))
        //                                    {
        //                                        pred = observer.VertexPredecessors[pred.Source];
        //                                    }
        //                                    else
        //                                    {
        //                                        inner.Add(pred.Source);
        //                                        break;
        //                                    }
        //                                }
        //                            }

        //                            inner.Reverse();
        //                            lstttt.Add(inner);
        //                        }
        //                    }
        //                }
        //            };

        //            dfs.DiscoverVertex += v =>
        //            {
        //                if (v != station)
        //                {
        //                    var l = _graph.OutEdges(v);
        //                    //var predessors = observer.VertexPredecessors;
        //                    //predessors.Add(station, null);
        //                    if (l.Any(adj => observer.VertexPredecessors.ContainsKey(adj.Target) || adj.Target == station))
        //                    {
                                
        //                        var connectedToCyclic = l.Where(adj => lstttt.Any(ll => ll.Contains(adj.Target)) || adj.Target == station);
        //                        foreach (var backEnd in connectedToCyclic)
        //                        {
        //                            var inner = new List<string>();
        //                            var pred = observer.VertexPredecessors[backEnd.Target];
        //                            while (pred != null)
        //                            {
        //                                inner.Add(pred.Target);
        //                                if (observer.VertexPredecessors.ContainsKey(pred.Source))
        //                                {
        //                                    pred = observer.VertexPredecessors[pred.Source];
        //                                }
        //                                else
        //                                {
        //                                    inner.Add(pred.Source);
        //                                    break;
        //                                }
        //                            }

        //                            pred = observer.VertexPredecessors.Last().Value;
        //                            while (pred != null)
        //                            {
        //                                inner.Add(pred.Target);
        //                                if (observer.VertexPredecessors.ContainsKey(pred.Source))
        //                                {
        //                                    pred = observer.VertexPredecessors[pred.Source];
        //                                }
        //                                else
        //                                {
        //                                    inner.Add(pred.Source);
        //                                    break;
        //                                }
        //                            }
        //                            inner.Reverse();
        //                            lstttt.Add(inner);


        //                        //    var cyclesToJoin = lstttt.Where(ll => ll.Contains(edge.Target));
        //                        //    foreach (var cycle in cyclesToJoin)
        //                        //    {
        //                        //        for (int i = 1; i < cycle.Count-1; i++)
        //                        //        {
        //                        //            inner.Add(cycle[i]);
        //                        //        }
        //                        //    }
        //                        }
        //                    }
        //                }
        //            };
        //            dfs.Compute(station);
        //            //dfs.Visit(station);
        //        }
        //    }

        //    var stringCycles = lstttt.Select(
        //        pathList =>
        //        {
        //            var fffstr = "";
        //            pathList.ForEach(s => fffstr += s + "-");
        //            fffstr = fffstr.TrimEnd('-');
        //            return fffstr;
        //        });
            
        //    var g = dfs.VisitedGraph;
        //    //var c = dfs.GetVertexColor("MAKSIMIR");
        //    //c = dfs.GetVertexColor("SIGET");
        //    //c = dfs.GetVertexColor("DUBRAVA");
        //    //c = dfs.GetVertexColor("MEDVESCAK");
        //    //var fffstr = "";
        //    //IEnumerable<Edge<string>> edges;
        //    //if (observer.TryGetPath(station, out edges))
        //    //{
        //    //    fffstr = "To get to vertex '" + station + "', take the following edges:";
        //    //    foreach (var edge in edges)
        //    //        fffstr+=edge.Source + " -> " + edge.Target;
        //    //}

        //    //foreach (var kv in observer.VertexPredecessors)
        //    //{
        //    //    //var strPath = kv.ToString();
        //    //    //strPath = kv.Key;
        //    //    //strPath += "-" + kv.Value.Source;
        //    //    //strPath = strPath.TrimEnd('-');
        //    //}

        //    #region tarjan strong components
        //    //IDictionary<string, int> components = new Dictionary<string, int>();  //Key: vertex, Value: subgraph index, 0-based.
        //    //_graph.StronglyConnectedComponents(out components);
        //    //Console.WriteLine("Graph contains {0} strongly connected components", components.Count);
        //    //foreach (var component in components)
        //    //{
        //    //    var s = component.ToString();
                
        //    //    Console.WriteLine("Vertex {0} is connected to subgraph {1}", component.Key, component.Value);
        //    //}
            
        //    //// Group and filter the dictionary
        //    //var cycles = components
        //    //    .GroupBy(x => x.Value, x => x.Key)
        //    //    //.Where(x => x.Count() > 1)
        //    //    .Select(x => x.ToList()).ToList();
        //    //var stringCycles = cycles.Select(
        //    //    pathList =>
        //    //    {
        //    //        fffstr = "";
        //    //        pathList.ForEach(s => fffstr += s + "-");
        //    //        fffstr = fffstr.TrimEnd('-');
        //    //        return fffstr;
        //    //    });
        //    #endregion

        //    return stringCycles;
        //}

        //void dfs_TreeEdge(Edge<string> e)
        //{
        //    throw new NotImplementedException();
        //}

        

        

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