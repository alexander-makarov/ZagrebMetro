using System;
using System.Collections.Generic;
using QuickGraph;
using QuickGraph.Algorithms;

namespace MetroNetwork
{
    public static class ShortestCycleIncludedAGivenVertex
    {
        public static bool TryGetDistanceFloydWarshall<TVertex, TEdge, TGraph>(TGraph visitedGraph, Dictionary<TEdge, double> costs, TVertex vertexToInclude, out double shortestCycleVertexIncludedTotalCost)
            where TEdge : IEdge<TVertex>
            where TGraph : IVertexAndEdgeListGraph<TVertex, TEdge>
        {
            //var obj = (TEdge)Activator.CreateInstance(typeof(TEdge), vertexToInclude, vertexToInclude);
            var infiniteSelfCostForAGivenVertex = new Dictionary<TEdge, double>(costs);
            infiniteSelfCostForAGivenVertex.Add(
                (TEdge)Activator.CreateInstance(typeof(TEdge), vertexToInclude, vertexToInclude), 
                Double.PositiveInfinity);
            var edgeCost = AlgorithmExtensions.GetIndexer(costs);

            IVertexAndEdgeListGraph<TVertex, TEdge> g = visitedGraph;
            var algorithm = new FloydWarshallAllShortestPathAlgorithmAllowNotZeroSelfCost<TVertex, TEdge, TGraph>(visitedGraph, edgeCost);

            algorithm.Compute();

            return algorithm.TryGetDistance(vertexToInclude, vertexToInclude, out shortestCycleVertexIncludedTotalCost);
        }
    }
}