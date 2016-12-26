using System.Collections.Generic;

namespace MetroNetwork
{
    public interface IMetroNetworkGraph
    {
        void ReadFromString(string metroNetworkGraphStr);
        double GetPathDistanceBetweenStations(string from, string to);
        double GetAdjacentPathDistanceBetweenStations(string from, string to);

        IEnumerable<string> GetRoundTripsForStation(string station);
        IEnumerable<string> GetAllPossibleTripsBetweenStations(string start, string end, int exactStopsInBetween);
    }
}