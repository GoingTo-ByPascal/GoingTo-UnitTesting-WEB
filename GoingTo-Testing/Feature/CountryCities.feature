Feature: CountryCities
	In order to get locatales
	As a goingto user
	I want to be told the result code

@mytag
Scenario: User search one city
	Given I have use the Get verb filtering  by country
	When I press the search buttom
	Then the result code should be 200 on the desktop
