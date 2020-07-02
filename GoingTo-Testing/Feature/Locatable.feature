Feature: Locatable
	In order to get locatales
	As a goingto user
	I want to be told the result code

@mytag
Scenario: Search locatable
	Given I search for a locatable with the GET verb
	When I execute the request
	Then the result should be 200
