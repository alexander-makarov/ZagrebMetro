using System;
using System.ServiceModel;
using MetroNetwork;
using RestRequestHelpers;
using ZagrebMetroService;

namespace ZagrebMetroClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var graph = new MetroNetworkGraph();
			graph.ReadFromString(
				@"MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8, MEDVESCAK-DUBRAVA:6, 
				  MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3, MAKSIMIR-DUBRAVA:7"); //, SPANSKO-T:2, T-DUBRAVA:2
			var metro = new ZagrebMetro(graph);
			
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

				#region RestRequest fooling around				
				////var jsonSerializerSettings = new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.All};
				//var jsonContent = JsonConvert.SerializeObject(new StationsPair { End = "e1", Start = "st1" });// "{\"stations\":\"spanko\"}"; //
				////jsonContent = "{ \"stations\" : { \"start\" : \"SIGET\", \"end\" : \"SIGET\" } }";
				//var jsonContent = "{ \"stations\" : { \"start\" : \"MAKSIMIR\", \"end\" : \"SPANSKO\" }, \"stops\": 4 }";
				//var jsonString = RestRequestHelper.POST(@"http://localhost:8733/zagreb-metro/trip/count/", jsonContent);
				////var jsonString = RestRequestHelper.GET(@"http://localhost:8733/zagreb-metro/trip/round/count/SPANSKO"); 
				//Console.WriteLine("Response JSON={0}", jsonString);				
				#endregion

				Console.ReadLine();

				// Close the ServiceHost.
				host.Close();
			}
		}
	}
}
