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


        public int GetTripDistance(IEnumerable<string> stations)
        {
            return 9;
        }
    }
}
