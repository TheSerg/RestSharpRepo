@weatherApi
Feature: WeatherAPI
	I need to prepare some weather data
	As really bad weather guy
	I just rip it of the net

	@positive
Scenario: Request weather data using valid city id
	When Weather for city with id 3081368 is requested
	Then Http response code is OK

	@positive
Scenario: Request weather data using valid city name
	When Weather for city with name Wroclaw is requested
	Then Http response code is OK

Scenario: Request weather data using valid city name Warszawa
	When Weather for city with name Warszawa is requested
	Then Http response code is OK

Scenario: Request weather data using valid city name Rzeszow
	When Weather for city with name Rzeszów is requested
	Then Http response code is OK

	@negative
Scenario: Request weather data using invalid city id
	When Weather for city with wrong id Wroclaw is requested
	Then Http response code is BadRequest

Scenario: Request London and check city name
	When Weather for city with name London is requested
	Then I see city name "London"

Scenario: Request London and check status code response
	When Weather for city with name London is requested
	Then I see code response "200"

Scenario: Regsitration new user
	When I register new user

Scenario: Login into rest api
	When Login user with username "ToolsQA" and password "TestPassword"

Scenario: Get with empty request
	When send empty request

Scenario: Get with multiple instance of some key
	When Get with multiple instance of some key

Scenario: Get with resource containing null token
	When Get with resource containing null token

Scenario: Get with resource contaning tokens
	When Get with resource contaning tokens

Scenario: Post with resurce containing tokens
	When I send POST with token

Scenario: Build URI using ISO-8859-1 encoding
	When Build end encoding URI using ISO-8859-1

Scenario: Get with resource containing slashes
	When Get with resource containing slashes

Scenario: Get with invalid URL string throws exception
	When get invalid url string throws exception

Scenario: Can deserialize elements with namespace
	When User deserialize elements with namespace

Scenario: Authenticate - Http autorization header handling
	When autenticate - HTTP autorization header


