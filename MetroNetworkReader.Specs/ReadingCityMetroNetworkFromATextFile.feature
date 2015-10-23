Feature: Reading City Metro network from a text file
	As a City Metro manager
	I want to be able to read in a text file that contains data about City Metro network

Background: 
	Given I have a new metro network graph

Scenario: Read metro network graph from a string
	Given The following metro network string have been provided 
		"""
		MAKSIMIR-SIGET:5, SIGET-SPANSKO:4, SPANSKO-MEDVESCAK:8, MEDVESCAK-SPANSKO:8,
		MEDVESCAK-DUBRAVA:6, MAKSIMIR-MEDVESCAK:5, SPANSKO-DUBRAVA:2, DUBRAVA-SIGET:3,
		MAKSIMIR-DUBRAVA:7
		"""
	When I read the metro network graph from a string
	Then all from the following connections should be printed on a screen:
		| FromToConnections					|
		| From MAKSIMIR to SIGET -> 5		|
		| From SIGET to SPANSKO -> 4		|
		| From SPANSKO to MEDVESCAK -> 8	|
		| From MEDVESCAK to SPANSKO -> 8	|
		| From MEDVESCAK to DUBRAVA -> 6	|
		| From MAKSIMIR to MEDVESCAK -> 5	|
		| From SPANSKO to DUBRAVA -> 2		|
		| From DUBRAVA to SIGET -> 3		|
		| From MAKSIMIR to DUBRAVA -> 7		|
	
