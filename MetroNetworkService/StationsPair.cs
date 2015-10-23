using System.Runtime.Serialization;

namespace MetroNetworkService
{
    //[DataContract]
    [DataContract(Name = "stations")]
    public struct StationsPair
    {
        //[DataMember]
        [DataMember(Name = "start", EmitDefaultValue = false)]
        public string Start { get; set; }
        //[DataMember]
        [DataMember(Name = "end", EmitDefaultValue = false)]
        public string End { get; set; }
    }
}