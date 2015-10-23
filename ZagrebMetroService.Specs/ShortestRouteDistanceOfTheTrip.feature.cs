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
    public partial class ShortestRouteDistanceOfTheTripFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ShortestRouteDistanceOfTheTrip.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Shortest route distance of the trip", "As a citizen or a visitor to Zagreb\r\nI want to be able to find the shortest route" +
                    " (distance of travel) between two stations (can be different or the same start a" +
                    "nd stop stations)\r\nusing HTTP REST services which output JSON data", ProgrammingLanguage.CSharp, new string[] {
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Shortest route distance of the trip")))
            {
                ZagrebMetroService.Specs.ShortestRouteDistanceOfTheTripFeature.FeatureSetup(null);
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
        
        public virtual void FindOutTheShortestRoutDistanceOfTheTrip(string name, string stationPairs, string distanceOfTheTrip, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find out the shortest rout distance of the trip", exampleTags);
#line 15
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 16
 testRunner.Given(string.Format("the following JSON data structure with stations provided \'{0}\'", stationPairs), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.When("I request: POST /zagreb-metro/trip/shortest/", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then(string.Format("I get as a response the following JSON data structure \'{0}\'", distanceOfTheTrip), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find out the shortest rout distance of the trip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Shortest route distance of the trip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("operateOnSelfHostedWcfService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "DistanceMaksimirSpansko9")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "DistanceMaksimirSpansko9")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:stationPairs", "{ \"stations\" : { \"start\" : \"MAKSIMIR\", \"end\" : \"SPANSKO\" } }")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:distanceOfTheTrip", "{ \"distance\" : 9 }")]
        public virtual void FindOutTheShortestRoutDistanceOfTheTrip_DistanceMaksimirSpansko9()
        {
            this.FindOutTheShortestRoutDistanceOfTheTrip("DistanceMaksimirSpansko9", "{ \"stations\" : { \"start\" : \"MAKSIMIR\", \"end\" : \"SPANSKO\" } }", "{ \"distance\" : 9 }", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find out the shortest rout distance of the trip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Shortest route distance of the trip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("operateOnSelfHostedWcfService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "DistanceSigetSiget9")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "DistanceSigetSiget9")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:stationPairs", "{ \"stations\" : { \"start\" : \"SIGET\", \"end\" : \"SIGET\" } }")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:distanceOfTheTrip", "{ \"distance\" : 9 }")]
        public virtual void FindOutTheShortestRoutDistanceOfTheTrip_DistanceSigetSiget9()
        {
            this.FindOutTheShortestRoutDistanceOfTheTrip("DistanceSigetSiget9", "{ \"stations\" : { \"start\" : \"SIGET\", \"end\" : \"SIGET\" } }", "{ \"distance\" : 9 }", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Find out the shortest rout distance of the trip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Shortest route distance of the trip")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("operateOnSelfHostedWcfService")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "NoSuchRoute")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Name", "NoSuchRoute")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:stationPairs", "{ \"stations\" : { \"start\" : \"DUBRAVA\", \"end\" : \"MAKSIMIR\" } }")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:distanceOfTheTrip", "{ \"distance\" : \"NO SUCH ROUTE\" }")]
        public virtual void FindOutTheShortestRoutDistanceOfTheTrip_NoSuchRoute()
        {
            this.FindOutTheShortestRoutDistanceOfTheTrip("NoSuchRoute", "{ \"stations\" : { \"start\" : \"DUBRAVA\", \"end\" : \"MAKSIMIR\" } }", "{ \"distance\" : \"NO SUCH ROUTE\" }", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion
