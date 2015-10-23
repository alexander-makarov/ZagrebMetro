using System.Runtime.Serialization;

namespace MetroNetworkService
{
    [DataContract]
    public struct StationsPair
    {
        [DataMember]
        public string Start { get; set; }
        [DataMember]
        public string End { get; set; }
    }
}