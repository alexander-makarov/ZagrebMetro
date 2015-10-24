@operateOnSelfHostedWcfService
Feature: Round trips for station
	As a citizen or visitor to Zagreb 
	I want to be able to find out how many trips there are starting and ending at the same station with a maximum of 3 stops
	using HTTP REST services which output JSON data

Background: 
	Given I have a deployed HTTP REST service with the following metro network graph:
		"""
		MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8,
		MEDVESCAK-DUBRAVA:6, MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3,
		MAKSIMIR-DUBRAVA:7
		"""

Scenario Outline: Find out trips which are starting and ending at the same station with a maximum of 3 stops
	When GET /zagreb-metro/trip/round/count/'<station>'
	Then I get as a response the following JSON data structure '<roundTrips>'	
	Examples: 
		|		 Name			| station		| roundTrips																							|
		|	RoundTripsSpansko	| SPANSKO 		| { "count" : 2, "roundtrips" : ["SPANSKO-MEDVESCAK-SPANSKO", "SPANSKO-DUBRAVA-SIGET-SPANSKO"] }		|
		
