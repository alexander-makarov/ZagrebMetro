using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MetroNetworkService
{
    [DataContract]
    public class RoundTripsList
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
        [DataMember(Name = "roundtrips", EmitDefaultValue = false)]
        public List<string> RoundTrips { get; set; }
    }
}