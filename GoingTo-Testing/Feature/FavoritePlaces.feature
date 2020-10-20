Feature: Set favorite places
	In order to save a place that I like
	I could save a place as a favorite place
	that is related with my account

@mytag
Scenario: Save a place as favorite
	Given A List of places
	When I select {place}
	Then the result should be 200

Scenario: failed save place as favorite
	Given A place that is show
	When Select a {place}
	Then the result should be 400
