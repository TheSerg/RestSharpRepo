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

	@negative
Scenario: Request weather data using invalid city id
	When Weather for city with wrong id Wroclaw is requested
	Then Http response code is BadRequest

