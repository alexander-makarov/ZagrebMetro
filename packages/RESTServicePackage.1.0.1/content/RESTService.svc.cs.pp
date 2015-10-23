using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.IO;
using System.Xml;

namespace $rootnamespace$
{
    [ServiceContract]
    public class RESTService 
    {
        [WebGet(UriTemplate = "{msg}")]
        [OperationContract]
        public string SayHello(string msg)
        {
            return "Hello " + msg + " from my REST service";
        }
    }
}
