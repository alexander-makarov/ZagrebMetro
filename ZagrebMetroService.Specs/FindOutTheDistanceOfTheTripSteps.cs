using System;
using MetroNetwork;
using TechTalk.SpecFlow;

namespace ZagrebMetroService.Specs
{
    [Binding]
    public class FindOutTheDistanceOfTheTripSteps
    {
        [Given(@"I have a deployed HTTP REST service with the following metro network graph:")]
        public void GivenIHaveADeployedHTTPRESTServiceWithTheFollowingMetroNetworkGraph(string multilineText)
        {
            var metroNetworkGraph = new MetroNetworkGraph();
            metroNetworkGraph.ReadFromString(multilineText);

            var zgMetro = new ZagrebMetro(metroNetworkGraph);
            
        }
        
        [Given(@"the following JSON data structure with stations provided")]
        public void GivenTheFollowingJSONDataStructureWithStationsProvided(string multilineText)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I request: POST /zagreb-metro/trip/distance")]
        public void WhenIRequestPOSTZagreb_MetroTripDistance()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I get as a response the following JSON data structure")]
        public void ThenIGetAsAResponseTheFollowingJSONDataStructure(string multilineText)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
