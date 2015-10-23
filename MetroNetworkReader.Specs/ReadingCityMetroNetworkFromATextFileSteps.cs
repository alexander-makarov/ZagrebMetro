using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using MetroNetwork;
using TechTalk.SpecFlow.Assist;

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

        [Then(@"all from the following connections should be printed on a screen:")]
        public void ThenAllFromTheFollowingConnectionsShouldBePrintedOnAScreen(Table table)
        {
            var metroString = _metroNetwork.ToString();
            var fromToConnectionsToExists = table.Rows.ToList();

            fromToConnectionsToExists.ForEach(connectionToExist =>
            {
                var expectedToContain = connectionToExist.Values.First();
                Assert.IsTrue(metroString.Contains(expectedToContain), "Expected - '"+expectedToContain+"'");
            });
        }
    }
}
