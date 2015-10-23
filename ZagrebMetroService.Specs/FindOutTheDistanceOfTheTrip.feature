@operateOnSelfHostedWcfService
Feature: Find out the distance of the trip
	As a citizen or a visitor to Zagreb
	I want to be able to find out the distance of the trip (a series of routes)
	using HTTP REST services which output JSON data

Background: 
	Given I have a deployed HTTP REST service with the following metro network graph:
		"""
		MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8,
		MEDVESCAK-DUBRAVA:6, MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3,
		MAKSIMIR-DUBRAVA:7
		"""

Scenario Outline: f
	Given the following JSON data structure with stations provided '<stationsOfTheTrip>'	  
	When I request: POST /zagreb-metro/trip/distance
	Then I get as a response the following JSON data structure '<distanceOfTheTrip>'	
	Examples: 
		|		 Name		| stationsOfTheTrip																| distanceOfTheTrip					|
		|	 Distance9		| { "stations" : ["MAKSIMIR", "SIGET", "SPANSKO"] }								| { "distance" : 9 }				|
		|	 Distance5		| { "stations" : ["MAKSIMIR", "MEDVESCAK"] }									| { "distance" : 5 }				|
		|	 Distance13		| { "stations" : ["MAKSIMIR", "MEDVESCAK", "SPANSKO"] }							| { "distance" : 13 }				|
		|	 Distance22		| { "stations" : ["MAKSIMIR", "DUBRAVA", "SIGET", "SPANSKO", "MEDVESCAK"] }		| { "distance" : 22 }				|
		|	 NoSuchRoute	| { "stations" : ["MAKSIMIR", "DUBRAVA", "MEDVESCAK"] }							| { "distance" : "NO SUCH ROUTE" }	|
