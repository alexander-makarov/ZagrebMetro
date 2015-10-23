using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MetroNetworkService
{
    [ServiceContract(Namespace = "http://www.corvus.hr/ZagrebMetro/2015/10")]
    public interface IMetroNetworkService
    {
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "trip/distance/")]
        [return: MessageParameter(Name = "distance")]
        [OperationContract]
        int GetTripDistance(IEnumerable<string> stations);
    }
}
