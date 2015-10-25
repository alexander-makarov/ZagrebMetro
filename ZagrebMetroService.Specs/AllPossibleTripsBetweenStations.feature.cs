﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ZagrebMetroService.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class AllPossibleTripsBetweenStationsWithExactly4StopsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AllPossibleTripsBetweenStations.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "All possible trips between stations with exactly 4 stops", "As a citizen or visitor to Zagreb \r\nI want to be able to find out how many trips " +
                    "there are starting at one station and ending at another station with exactly 4 s" +
                    "tops\r\nusing HTTP REST services which output JSON data", ProgrammingLanguage.CSharp, new string[] {
                        "operateOnSelfHostedWcfService"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "All possible trips between stations with exactly 4 stops")))
            {
                ZagrebMetroService.Specs.AllPossibleTripsBetweenStationsWithExactly4StopsFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line hidden
#line 8
 testRunner.Given("I have a deployed HTTP REST service with the following metro network graph:", "MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8,\r\nMED" +
                    "VESCAK-DUBRAVA:6, MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3,\r\nMAK" +
                    "SIMIR-DUBRAVA:7", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        public virtual void FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops(string name, string stationPairsAndStopsInBetweenAmount, string allPossibleTripsWithAmountOfStops, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find out how many trips there are starting at one station and ending at another s" +
                    "tation with exactly 4 stops", exampleTags);
#line 15
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 16
 testRunner.Given(string.Format("the following JSON data structure with stations provided \'{0}\'", stationPairsAndStopsInBetweenAmount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.When("I request: POST /zagreb-metro/trip/count", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then(string.Format("I get as a response the following JSON data structure \'{0}\'", allPossibleTripsWithAmountOfStops), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find out how many trips there are starting at one station and ending at another s" +
            "tation with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "All possible trips between stations with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("operateOnSelfHostedWcfService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "MaksimirSpansko")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "MaksimirSpansko")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:StationPairsAndStopsInBetweenAmount", "{ \"stations\" : { \"start\" : \"MAKSIMIR\", \"end\" : \"SPANSKO\" }, \"stops\": 4 }")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:AllPossibleTripsWithAmountOfStops", "{ \"count\" : 3, \"stops\" : [ “SIGET-SPANSKO-MEDVESCAK”, “MEDVESCAK-SPANSKO-MEDVESCA" +
            "K”, “MEDVESCAK-DUBRAVA-SIGET”]}")]
        public virtual void FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops_MaksimirSpansko()
        {
            this.FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops("MaksimirSpansko", "{ \"stations\" : { \"start\" : \"MAKSIMIR\", \"end\" : \"SPANSKO\" }, \"stops\": 4 }", "{ \"count\" : 3, \"stops\" : [ “SIGET-SPANSKO-MEDVESCAK”, “MEDVESCAK-SPANSKO-MEDVESCA" +
                    "K”, “MEDVESCAK-DUBRAVA-SIGET”]}", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find out how many trips there are starting at one station and ending at another s" +
            "tation with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "All possible trips between stations with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("operateOnSelfHostedWcfService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "SigetSiget")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "SigetSiget")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:StationPairsAndStopsInBetweenAmount", "{ \"stations\" : { \"start\" : \"SIGET\", \"end\" : \"SIGET\" }, \"stops\": 4 }")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:AllPossibleTripsWithAmountOfStops", "{ \"distance\" : 9 }")]
        public virtual void FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops_SigetSiget()
        {
            this.FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops("SigetSiget", "{ \"stations\" : { \"start\" : \"SIGET\", \"end\" : \"SIGET\" }, \"stops\": 4 }", "{ \"distance\" : 9 }", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find out how many trips there are starting at one station and ending at another s" +
            "tation with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "All possible trips between stations with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("operateOnSelfHostedWcfService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "NoSuchRoute")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "NoSuchRoute")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:StationPairsAndStopsInBetweenAmount", "{ \"stations\" : { \"start\" : \"DUBRAVA\", \"end\" : \"MAKSIMIR\" }, \"stops\": 4 }")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:AllPossibleTripsWithAmountOfStops", "{ \"distance\" : \"NO SUCH ROUTE\" }")]
        public virtual void FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops_NoSuchRoute()
        {
            this.FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops("NoSuchRoute", "{ \"stations\" : { \"start\" : \"DUBRAVA\", \"end\" : \"MAKSIMIR\" }, \"stops\": 4 }", "{ \"distance\" : \"NO SUCH ROUTE\" }", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find out how many trips there are starting at one station and ending at another s" +
            "tation with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "All possible trips between stations with exactly 4 stops")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("operateOnSelfHostedWcfService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "SpanskoSpansko")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "SpanskoSpansko")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:StationPairsAndStopsInBetweenAmount", "{ \"stations\" : { \"start\" : \"SPANSKO\", \"end\" : \"SPANSKO\" }, \"stops\": 4 }")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:AllPossibleTripsWithAmountOfStops", "{ \"distance\" : 9 }")]
        public virtual void FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops_SpanskoSpansko()
        {
            this.FindOutHowManyTripsThereAreStartingAtOneStationAndEndingAtAnotherStationWithExactly4Stops("SpanskoSpansko", "{ \"stations\" : { \"start\" : \"SPANSKO\", \"end\" : \"SPANSKO\" }, \"stops\": 4 }", "{ \"distance\" : 9 }", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion
