Feature: DestinyInformation
	In order to get information from places
    As a goingto User
    I want to be told the result

@mytag
Scenario: Get locatable information
	Given I search for information by locatables
	When I interact with the search
	Then the result should be 200
