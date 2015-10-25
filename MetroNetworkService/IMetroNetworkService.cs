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
        object GetTripDistance(IEnumerable<string> stations);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "trip/shortest/")]
        [return: MessageParameter(Name = "distance")]
        [OperationContract]
        object GetShortestTripDistance(StationsPair stations);

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "trip/round/count/{station}")]
        [OperationContract]
        RoundTripsList GetRoundTripsForStation(string station);

        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "trip/count/")]
        [OperationContract]
        StopsInTripsList GetAllPossibleTripsBetweenStations(StationsPair stations, int exactStopsInBetween);
    }
}
