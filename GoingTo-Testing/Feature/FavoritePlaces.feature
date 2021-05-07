Feature: Set favorite places
	In order to save a place that I like
	I could save a place as a favorite place
	that is related with my account

@mytag
Scenario: Save a place as favorite
	Given A List of places
	When I select 1
	Then the result should  be 204

Scenario: failed save place as favorite
	Given A List of  places
	When I Select a the place with id 999
	Then the result should  be 400
