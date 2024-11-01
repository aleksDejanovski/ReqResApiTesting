Feature: Users

A short summary of the feature

@tag1
Scenario: Get all users => HTTP 200 
	When I send GET request to the /users endpoint
	Then The response code is HTTP 200


Scenario: Get all users => HTTP 200 and check content for given string
	When I send GET request to the /users endpoint
	Then The response code is HTTP 200
	And The response contains "janet.weaver@reqres.in"


Scenario: Get specific user => HTTP 200 and check name of the response
	When I send GET request to the /users/{id} endpoint using "2" as an id
	Then The response code is HTTP 200
	And The response contains "janet.weaver@reqres.in"
	And The property first_name has a value "Janet"


Scenario: Get User and check that does not contain property for other user => HTTP 200 and check response name content
	When I send GET request to the /users/{id} endpoint using "6" as an id
	Then The response code is HTTP 200
	And The response contains "Tracey"
	And The property first_name does not contain value as "Janet"


Scenario: Get user using invalid id => HTTP 404 user not found
	When I send GET request to the /users/{id} endpoint using "0" as an id
	Then The response code is HTTP 404
	And The response contains ""

	
Scenario: Get user using invalid format id as string => HTTP 404 not found or HTTP 400 bad request
	When I send GET request to the /users/{id} endpoint using "test12" as an id
	Then The response code is HTTP 404


Scenario: Get user using large number id => HTTP 404
	When I send GET request to the /users/{id} endpoint using "554547777777234243434342342342" as an id
	Then The response code is HTTP 404


Scenario: Create  not valid user => HTTP 400
	When I Create a valid user with username "", email as "aleks@yahoo.com" and random password
	Then The response code is HTTP 400
	And The response contains "Missing email or username"
	