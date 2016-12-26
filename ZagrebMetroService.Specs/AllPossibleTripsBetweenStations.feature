@operateOnSelfHostedWcfService
Feature: All possible trips between stations with exactly 4 stops
	As a citizen or visitor to Zagreb 
	I want to be able to find out how many trips there are starting at one station and ending at another station with exactly 4 stops
	(it's okay to have the same station a few times)
	using HTTP REST services which output JSON data

Background: 
	Given I have a deployed HTTP REST service with the following metro network graph:
		"""
		MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8,
		MEDVESCAK-DUBRAVA:6, MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3,
		MAKSIMIR-DUBRAVA:7
		"""

Scenario Outline: Find out how many trips there are starting at one station and ending at another station with exactly 4 stops
	Given the following JSON data structure with stations provided '<StationPairsAndStopsInBetweenAmount>'	  
	When I request: POST /zagreb-metro/trip/count
	Then I get as a response the following JSON data structure '<AllPossibleTripsWithAmountOfStops>'	
	Examples: 
		|		 Name				| StationPairsAndStopsInBetweenAmount										| AllPossibleTripsWithAmountOfStops																							|
		|	 MaksimirSpansko		| { "stations" : { "start" : "MAKSIMIR", "end" : "SPANSKO" }, "stops": 4 }	| { "count" : 3, "stops" : [ "SIGET-SPANSKO-MEDVESCAK", "MEDVESCAK-SPANSKO-MEDVESCAK", "MEDVESCAK-DUBRAVA-SIGET"] }			|
		|	 SigetSiget				| { "stations" : { "start" : "SIGET", "end" : "SIGET" }, "stops": 4 }		| { "count" : 1, "stops" : [ "SPANSKO-MEDVESCAK-DUBRAVA" ]  }																|
		|	 NoSuchRoute			| { "stations" : { "start" : "DUBRAVA", "end" : "MAKSIMIR" }, "stops": 4 }	| { "count" : 0, "stops" : [] }																								|
		|	 SpanskoSpansko			| { "stations" : { "start" : "SPANSKO", "end" : "SPANSKO" }, "stops": 4 }	| { "count" : 2, "stops" : [ "MEDVESCAK-SPANSKO-MEDVESCAK", "MEDVESCAK-DUBRAVA-SIGET"]  }									|

		
