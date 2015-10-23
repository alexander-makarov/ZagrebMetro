using System.Collections.Generic;
using System.ServiceModel;

namespace MetroNetworkService
{
    [ServiceContract(Namespace = "http://www.corvus.hr/ZagrebMetro/2015/10")]
    public interface IMetroNetworkService
    {
        [OperationContract]
        string GetTripDistance(IEnumerable<string> stationsList);
    }
}
