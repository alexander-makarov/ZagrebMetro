using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using MetroNetwork;

namespace MetroNetworkReader.Specs
{
    [Binding]
    public class ReadingCityMetroNetworkFromATextFileSteps
    {
        /// <summary>
        /// String representation of a metro network graph
        /// </summary>
        private string _metroNetworkStr;

        private MetroNetworkGraph _metroNetwork;

        [Given(@"I have a new metro network graph")]
        public void GivenIHaveANewMetroNetwork()
        {
            _metroNetwork = new MetroNetworkGraph();
        }


        [Given(@"The following metro network string have been provided")]
        public void GivenTheFollowingMetroNetworkStringHaveBeenProvided(string multilineText)
        {
            _metroNetworkStr = multilineText;
        }

        [When(@"I read the metro network graph from a string")]
        public void WhenIReadTheMetroNetworkString()
        {
            _metroNetwork.ReadFromString(_metroNetworkStr);
        }
        
        [Then(@"the following result should be printed on a screen")]
        public void ThenTheFollowingResultShouldBePrintedOnAScreen(string multilineText)
        {
            Assert.AreEqual(multilineText, _metroNetwork.ToString());
        }
    }
}
