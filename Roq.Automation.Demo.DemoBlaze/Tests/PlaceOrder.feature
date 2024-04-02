Feature: Place Order

Background:
	Given I am on the demo blaze website

Scenario: Successfully place an order


	Given I am on a product page
	And I add the product to my basket
	And I navigate to my basket
	When I place the order
	Then the order is placed