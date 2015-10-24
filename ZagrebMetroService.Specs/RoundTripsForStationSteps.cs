﻿using System;
using System.ServiceModel;
using MetroNetwork;
using MetroNetworkService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestRequestHelpers;
using TechTalk.SpecFlow;

namespace ZagrebMetroService.Specs
{
    //[Binding]
    //public class RoundTripsForStationSteps
    //{
    //    private static ServiceHost _host = null;
    //    private static string _jsonRequestContent;
    //    private static string _jsonResponseContent;

    //    [AfterScenario("operateOnSelfHostedWcfService")]
    //    public static void AfterAppFeature()
    //    {
    //        if (_host != null)
    //        {
    //            _host.Close();
    //        }
    //    }

    //    [Given(@"I have a deployed HTTP REST service with the following metro network graph:")]
    //    public void GivenIHaveADeployedHTTPRESTServiceWithTheFollowingMetroNetworkGraph(string multilineText)
    //    {
    //        var metroNetworkGraph = new MetroNetworkGraph();
    //        metroNetworkGraph.ReadFromString(multilineText);

    //        var zgMetro = new ZagrebMetro(metroNetworkGraph);

    //        // Create the ServiceHost.
    //        _host = new ServiceHost(zgMetro);
    //        _host.Open();
    //    }
        

    //    [Then(@"I get as a response the following JSON data structure '(.*)'")]
    //    public void ThenIGetAsAResponseTheFollowingJSONDataStructure(string expectedJsonResponse)
    //    {
    //        dynamic expected = JObject.Parse(expectedJsonResponse); //JsonConvert.DeserializeObject<RoundTripsList>(expectedJsonResponse);
    //        dynamic actual = JObject.Parse(_jsonResponseContent);
    //        Assert.IsTrue(JToken.DeepEquals(expected, actual), "expected: {0}, but actual:{1}", expected, actual);
    //    }

    //    [When(@"GET /zagreb-metro/trip/round/count/'(.*)'")]
    //    public void WhenGETZagreb_MetroTripRoundCount(string station)
    //    {
    //        _jsonResponseContent = RestRequestHelper.GET(@"http://localhost:8733/zagreb-metro/trip/round/count/"+station); 
    //    }

    //}
}