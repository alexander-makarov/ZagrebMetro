using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroNetwork
{
    public class MetroNetworkGraph
    {
        private readonly SortedList<string, SortedList<string, int>> _graphNodes = new SortedList<string, SortedList<string, int>>();
        public void ReadFromString(string metroNetworkGraphStr)
        {
            if(String.IsNullOrWhiteSpace(metroNetworkGraphStr))
                throw new ArgumentException("Metro network string either null, empty or consists only of whitespaces", "metroNetworkGraphStr");

            try
            {
                var edges = metroNetworkGraphStr.Split(',').Select(s => s.Trim());
                foreach (var edge in edges)
                {
                    var stationPairAndDistance = edge.Split(':');
                    var stationPair = stationPairAndDistance[0].Split('-');
                    var station1 = stationPair[0];
                    var station2 = stationPair[1];
                    var distance = Int32.Parse(stationPairAndDistance[1]);

                    if (!_graphNodes.ContainsKey(station1))
                    {
                        _graphNodes.Add(station1, new SortedList<string, int>());
                    }
                    _graphNodes[station1].Add(station2, distance);
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
            foreach (var station in _graphNodes)
            {
                foreach (var adjacentStation in station.Value)
                {
                    var stationFrom = station.Key;
                    var stationTo = adjacentStation.Key;
                    var distance = adjacentStation.Value;
                    sb.AppendFormat("From {0} to {1} -> {2}", stationFrom, stationTo, distance).AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}
