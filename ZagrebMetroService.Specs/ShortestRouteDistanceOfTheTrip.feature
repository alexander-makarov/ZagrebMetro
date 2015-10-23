@operateOnSelfHostedWcfService
Feature: Shortest route distance of the trip
	As a citizen or a visitor to Zagreb
	I want to be able to find the shortest route (distance of travel) between two stations (can be different or the same start and stop stations)
	using HTTP REST services which output JSON data

Background: 
	Given I have a deployed HTTP REST service with the following metro network graph:
		"""
		MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8,
		MEDVESCAK-DUBRAVA:6, MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3,
		MAKSIMIR-DUBRAVA:7
		"""

Scenario Outline: Find out the shortest rout distance of the trip
	Given the following JSON data structure with stations provided '<stationPairs>'	  
	When I request: POST /zagreb-metro/trip/shortest/
	Then I get as a response the following JSON data structure '<distanceOfTheTrip>'	
	Examples: 
		|		 Name						| stationPairs															| distanceOfTheTrip					|
		|	 DistanceMaksimirSpansko9		| { "stations" : { "start" : "MAKSIMIR", "end" : "SPANSKO" } } 			| { "distance" : 9 }				|
		|	 DistanceSigetSiget9			| { "stations" : { "start" : "SIGET", "end" : "SIGET" } }				| { "distance" : 9 }				|
		|	 NoSuchRoute					| { "stations" : { "start" : "DUBRAVA", "end" : "MAKSIMIR" } }			| { "distance" : "NO SUCH ROUTE" }	|
