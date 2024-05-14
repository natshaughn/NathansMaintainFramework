Feature: Product Page

As a customer
I want to view product information
So i can see the price and other information about the product

Background:
	Given I am on the demo blaze website

#Scenario: Product Page Displays Correct Price
#
#	When I open the product page for the "Samsung galaxy s6"
#	Then the price per unit is "360"


 Scenario Outline: Product Page displays the correct information 
    When I open the page for the <Product>
    Then the product description is <Description>
    And the price is <Price>
    And the product image is displayed 

  Examples:
    | Product             | Price | Description                                                                                                                                                                   |
    | Samsung galaxy s6   | 360   | The Samsung Galaxy S6 is powered by 1.5GHz octa-core Samsung Exynos 7420 processor and it comes with 3GB of RAM. The phone packs 32GB of internal storage cannot be expanded. |
    | Nokia lumia 1520    | 820   | The Nokia Lumia 1520 is powered by 2.2GHz quad-core Qualcomm Snapdragon 800 processor and it comes with 2GB of RAM.                                                           |
    | Nexus 6             | 650   | The Motorola Google Nexus 6 is powered by 2.7GHz quad-core Qualcomm Snapdragon 805 processor and it comes with 3GB of RAM.                                                    |
    | Samsung galaxy s7   | 800   | The Samsung Galaxy S7 is powered by 1.6GHz octa-core it comes with 4GB of RAM. The phone packs 32GB of internal storage that can be expanded up to 200GB via a microSD card.  |


#Scenario: Samsung galaxy s6 Product Page Displays Correct Product Description
#
#	When I open the product page for the "Samsung galaxy s6"
#	Then the product description is:
#		| description                                                                                                                                                                   |
#		| The Samsung Galaxy S6 is powered by 1.5GHz octa-core Samsung Exynos 7420 processor and it comes with 3GB of RAM. The phone packs 32GB of internal storage cannot be expanded. |
#
#Scenario: Product Page Displays Product Image
#
#	When I open the product page for the "Samsung galaxy s6"
#	Then the product image is displayed
#
#Scenario: Nokia lumia 1520 Product Page Displays Correct Product Description
#
#	When I open the product page for the "Nokia lumia 1520"
#	Then the product description is:
#		| description                                                                                                         |
#		| The Nokia Lumia 1520 is powered by 2.2GHz quad-core Qualcomm Snapdragon 800 processor and it comes with 2GB of RAM. |
#
#Scenario: Nexus 6 Product Page Displays Correct Product Description
#
#	When I open the product page for the "Nexus 6"
#	Then the product description is:
#		| description                                                                                                                |
#		| The Motorola Google Nexus 6 is powered by 2.7GHz quad-core Qualcomm Snapdragon 805 processor and it comes with 3GB of RAM. |
#
#Scenario: Samsung galaxy s7 Product Page Displays Correct Product Description
#
#	When I open the product page for the "Samsung galaxy s7"
#	Then the product description is:
#		| description                                                                                                                                                                  |
#		| The Samsung Galaxy S7 is powered by 1.6GHz octa-core it comes with 4GB of RAM. The phone packs 32GB of internal storage that can be expanded up to 200GB via a microSD card. |