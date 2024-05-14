Feature: Add A Product To Basket

As a customer
I want to add products to my basket
So I can see the total cost is correct 

Background:
	Given I am on the demo blaze website

Scenario: Add a product to my basket shows the correct price
	And I am on a product page
	When I add the product to my basket
	And I navigate to my basket
	Then the total of the basket is correct

Scenario: Add two products to my basket shows the correct price
	And I am on a product page
	When I add the product to my basket
	And I navigate to the home page
	And I am on a product page
	And I add the product to my basket
	And I navigate to my basket
	Then the total of the basket is correct

	@FailingTest
	#This test intentionally fails, do not modify it.
Scenario: Add a product to my basket shows the incorrect price
	And I am on a product page
	When I add the product to my basket
	And I navigate to my basket
	Then the total of my basket is 1000