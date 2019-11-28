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

Scenario: Request post data using existing id
	When I request for post data using id 3
	Then Http response code is OK

Scenario: Request comment data using existing id
	When I request for comment using id 3
	Then Http response code is OK

Scenario: Request user using existing id
	When I request for user using id 2
	Then Http response code is OK

Scenario: Request album using existing id
	When I request for album using id 5
	Then Http response code is OK

Scenario: Request todos using existing id
	When I request for todos using id 6
	Then Http response code is OK

Scenario: Request album with id 5 and check title name
	When I request for album using id 5
	Then Http response code is OK
	Then Album should have a title ""MyTitle""

Scenario: Request album with id 5 and check all data
	When I request for album using id 5
	Then Title is ""MyTitle""
	Then user id should be "101"
	Then url should be ""https://via.placeholder.com/669/e5109""
	Then thumbneil url should be ""https://via.placeholder.com/669/e5109""





	
	

