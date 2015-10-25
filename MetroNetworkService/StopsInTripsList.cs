using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MetroNetworkService
{
    [DataContract]
    public class StopsInTripsList
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
        [DataMember(Name = "stops", EmitDefaultValue = false)]
        public List<string> StopsInTrips { get; set; }
    }
}