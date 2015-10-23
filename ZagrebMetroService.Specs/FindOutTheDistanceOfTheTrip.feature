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

Scenario: Get distance of the trip 
	Given the following JSON data structure with stations provided
		"""
		{
			"stations" : ["MAKSIMIR", "SIGET", "SPANSKO"]
		}
		"""		
	When I request: POST /zagreb-metro/trip/distance
	Then I get as a response the following JSON data structure
		"""
		{
			"distance" : 9
		}
		"""	
