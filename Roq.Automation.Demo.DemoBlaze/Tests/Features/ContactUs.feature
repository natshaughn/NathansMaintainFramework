Feature: Contact Us

As a customer
I want their to be a contact us form
That I can fill out to contact the company

Background:
	Given I am on the demo blaze website

Scenario: Submit contact us form
	And I open the contact us menu
	When I complete the contact us form
	Then the contact us form is submitted