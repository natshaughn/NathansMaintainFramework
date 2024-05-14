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

#Scenario: Phone category available
# Given I am on the demo blaze website
# Then the "Phones" category is available
# 
#
#Scenario: Laptops category available
# Given I am on the demo blaze website
# Then the "Laptops" category is available
#
#
#Scenario: Monitors category available
# Given I am on the demo blaze website
# Then the "Monitors" category is available