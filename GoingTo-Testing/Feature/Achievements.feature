Feature: List Achievements
	In order to get the GoingTo achievements
	As a goingto User
	I want to be told the list of achievements in the system

@mytag
Scenario: Get system's Achievements
	Given I search for systems's achievements
	When I interact with the system
	Then the result of the operation should be 200
