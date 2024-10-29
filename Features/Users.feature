Feature: Users

A short summary of the feature

@tag1
Scenario: Get all users => HTTP 200 
	Given I send api call using HTTP client
	When I send GET request to the /users endpoint
	Then The response code is HTTP 200 success


Scenario: Get all users => HTTP 200 and check content for given string
	Given I send api call using HTTP client
	When I send GET request to the /users endpoint
	Then The response code is HTTP 200 success
	And The response contains "janet.weaver@reqres.in"