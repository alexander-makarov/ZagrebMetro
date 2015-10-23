using System.Collections.Generic;
using System.ServiceModel.Web;
using MetroNetwork;
using MetroNetworkService;

namespace ZagrebMetroService
{
    public class ZagrebMetro : IMetroNetworkService
    {
        private readonly MetroNetworkGraph _metroNetwork;

        public ZagrebMetro(MetroNetworkGraph metroNetwork)
        {
            _metroNetwork = metroNetwork;
        }

        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "trip/distance/{stationsList}")]
        public string GetTripDistance(IEnumerable<string> stationsList)
        {
            return "Got it!";
        }
    }
}
