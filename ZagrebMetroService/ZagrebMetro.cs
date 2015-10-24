using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using MetroNetwork;
using MetroNetworkService;

namespace ZagrebMetroService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ZagrebMetro : IMetroNetworkService
    {
        private readonly IMetroNetworkGraph _metroNetwork;

        public ZagrebMetro(IMetroNetworkGraph metroNetwork)
        {
            _metroNetwork = metroNetwork;
        }


        public object GetTripDistance(IEnumerable<string> stations)
        {
            var enumerable = stations as IList<string> ?? stations.ToList();
            var iter = enumerable.GetEnumerator();
            string from = null;
            var wholeDistance = 0.0;
            while (iter.MoveNext())
            {
                if (from != null)
                {
                    var distance = _metroNetwork.GetAdjacentPathDistanceBetweenStations(from, iter.Current);
                    if (distance < 0)
                    {
                        return "NO SUCH ROUTE";
                    }
                    wholeDistance += distance;
                }
                from = iter.Current;
            }

            return (int)wholeDistance;
        }

        public RoundTripsList GetRoundTripsForStation(string station)
        {
            var roundPathes = _metroNetwork.GetRoutingTripsForStation(station).ToList();
            return new RoundTripsList {RoundTrips = roundPathes, Count = roundPathes.Count};
        }

        public object GetShortestTripDistance(StationsPair stations)
        {
            var distance = _metroNetwork.GetPathDistanceBetweenStations(stations.Start, stations.End);
            if (distance < 0)
            {
                return "NO SUCH ROUTE";
            }
            return (int)distance;
        }
    }
}
