Feature: Place Order

As a customer
I want to add products to my basket
So I can place an order

Background:
	Given I am on the demo blaze website

Scenario: Successfully place an order
	And I am on a product page
	And I add the product to my basket
	And I navigate to my basket
	When I place the order
	Then the order is placed