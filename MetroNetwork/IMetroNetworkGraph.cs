namespace MetroNetwork
{
    public interface IMetroNetworkGraph
    {
        void ReadFromString(string metroNetworkGraphStr);
        double GetPathDistanceBetweenStations(string from, string to);
        double GetAdjacentPathDistanceBetweenStations(string from, string to);
    }
}