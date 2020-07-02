Feature: CityPlaces
    In order to get cities by place
    As a goingto User
    I want to be told the result

@mytag
Scenario: Get Places By City
    Given I search for places by city
    When I interact with the search 
    Then the result code should be 200

