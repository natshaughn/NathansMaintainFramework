Feature: Default Empty Basket

Background:
	Given I am on the demo blaze website

Scenario: By default my basket is empty

When I open the basket
Then my basket is empty