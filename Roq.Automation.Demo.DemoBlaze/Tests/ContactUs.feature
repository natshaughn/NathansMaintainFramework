Feature: Contact Us

Background:
	Given I am on the demo blaze website

Scenario: Open Contact Us Menu

	When I open the contact us menu
	Then the contact us menu is displayed

Scenario: Submit contact us form

	Given I open the contact us menu
	When I complete the contact us form
	Then the contact us form is submitted