Feature: Default Empty Basket

As a customer
I want to my default basket to be empty

Background:
	Given I am on the demo blaze website

Scenario: By default my basket is empty
	When I open the basket
	Then my basket is empty