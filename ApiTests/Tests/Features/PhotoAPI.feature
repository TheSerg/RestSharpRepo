	@photoApi
Feature: PlaceholderPhotos
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	@positive
Scenario: Request photo data using valid id
	When I request for photo data using valid photo id 2
	Then Http response code is OK

	@negative
Scenario: Request photo data using unexisting id
	When I request for photo data using unexisting photo id 9999999
	Then Http response code is NotFound

	@positive
Scenario: Posting photo data
	When I post valid data to the photo service
	Then Http response code is Created

	@positive
Scenario: Deleting photo data 
	When I delete photo data using Id 3 from the photo service
	Then Http response code is OK

Scenario: Request post data using unexisting id
	When I request for post data using id 3
	Then Http response code is OK

Scenario: Request comment data using unexisting id
	When I request for comment using id 3
	Then Http response code is OK
