﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using MetroNetwork;
using MetroNetworkService;
using Newtonsoft.Json;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Extensions.Wcf.SelfHost;
using Ninject.Web.Common.SelfHost;
using RestRequestHelpers;
using ZagrebMetroService;

namespace ZagrebMetroClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uri baseAddress = new Uri("http://localhost:8080/hello");
            var graph = new MetroNetworkGraph();
            graph.ReadFromString(
                @"MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8,
		MEDVESCAK-DUBRAVA:6, MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3,
		MAKSIMIR-DUBRAVA:7"); //, SPANSKO-T:2, T-DUBRAVA:2
            var metro = new ZagrebMetro(graph);
            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(metro))
            {
                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready");

                Console.WriteLine("Active endpoints:");
                foreach (var end in host.Description.Endpoints)
                {
                    Console.WriteLine("\t" + end.ListenUri);
                }

                Console.WriteLine();
                Console.WriteLine("Press <Enter> to stop the service.");

                #region

                
                //var l = new Msg() {stations = new List<string> {"gg", "tt"}};
                ////var jsonSerializerSettings = new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All};
                //var jsonContent = JsonConvert.SerializeObject(new StationsPair { End = "e1", Start = "st1" });// "{\"stations\":\"spanko\"}"; //
                ////jsonContent = "{ \"stations\" : { \"start\" : \"SIGET\", \"end\" : \"SIGET\" } }";
                //var jsonString = RestRequestHelper.POST(@"http://localhost:8733/zagreb-metro/trip/shortest/", jsonContent);
                var jsonString = RestRequestHelper.GET(@"http://localhost:8733/zagreb-metro/trip/round/count/SPANSKO"); 
                Console.WriteLine("Response JSON={0}", jsonString);

                
                #endregion

                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }

        public class Msg
        {
            public List<string> stations { get; set; } 
        }

        //private static NinjectSelfHostBootstrapper selfHost;
        //private static void StartNinjectSelfHost()
        //{
        //    var someWcfService = NinjectWcfConfiguration.Create<ZagrebMetro, NinjectServiceSelfHostFactory>();
        //    //var webApiConfiguration = new HttpSelfHostConfiguration("http://localhost:8080");
        //    //webApiConfiguration.Routes.MapHttpRoute(
        //    //            name: "DefaultApi",
        //    //            routeTemplate: "{controller}/{id}",
        //    //            defaults: new { id = RouteParameter.Optional, controller = "values" });

        //    selfHost = new NinjectSelfHostBootstrapper(
        //        CreateKernel,
        //        someWcfService,
        //        null);
        //    selfHost.Start();
        //}

        ///// <summary>
        ///// Creates the kernel.
        ///// </summary>
        ///// <returns>the newly created kernel.</returns>
        //private static StandardKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    return kernel;
        //}
    }
}
