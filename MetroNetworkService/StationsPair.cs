using System.Runtime.Serialization;

namespace MetroNetworkService
{
    [DataContract(Name = "stations")]
    public struct StationsPair
    {
        [DataMember(Name = "start", EmitDefaultValue = false)]
        public string Start { get; set; }
        [DataMember(Name = "end", EmitDefaultValue = false)]
        public string End { get; set; }
    }
}