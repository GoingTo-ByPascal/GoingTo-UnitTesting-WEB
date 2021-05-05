Feature: DestinationDescriptions
	In order to know more about a destionation in particular
	As a goingto user
	I want to see the description of each destination

@mytag
Scenario: See description
	Given I'm looking for a description of a destination
	When I  execute the request
	Then the  result should be 200

