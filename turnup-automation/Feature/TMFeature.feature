Feature: TMFeature

Via turnup portal, user should be able to create, edit and delete time and material records succesfully

Scenario: Create time and material record with valid details
	Given I logged into turnup portal succesfully
	When I navigate to time and material page
	And I create a new time and material record
	Then The record should be created succesfully

Scenario Outline: Edit existing time and material record with valid details
	Given I logged into turnup portal succesfully
	When I navigate to time and material page
	And I edit an existing time and material record '<Description>'
	Then The record should be updated succesfully

	Examples:
	| Description |
	| Keyboard    |
	| Pen		|
	| EditedRecord    |

Scenario: Delete existing time and material record
	Given I logged into turnup portal succesfully
	When I navigate to time and material page
	And I delete an existing time and material record
	Then The record should be deleted succesfully