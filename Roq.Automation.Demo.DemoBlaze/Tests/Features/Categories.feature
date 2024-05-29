Feature: Categories

As a customer
I want to see product specific category filters

Background:
    Given I am on the demo blaze website

Scenario Outline: Category is available
    Then the "<Category>" category is available

    Examples:
    | Category  |
    | Phones    |
    | Laptops   |
    | Monitors  |
