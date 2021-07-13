#############################################################
##Login as a registered user
##This feature is a journey to navigate to Bunnings homepage
##Search for a text based on the input in feature file
##See results, add quantity and click on add to cart
##Review cart
#############################################################
Feature: AddItemsToCart_RegisteredUser
	Login as a registered user
	A simple journey to navigate to Bunnings home page and search 
	Add items to cart
	Navigate to review cart and verify if items are successfully added
	Selenium c# miniature framework

@AddToCart
Scenario Outline: AddItemsToCart_ReviewCart
	Given I navigate to bunnings home page
	And I login to the bunnings website
	When I search for a <text>
	Then I can see the results and add to cart the first search result item
	And I add <quantity>
	And I navigate to review cart page from basket icon
	And I verify that the item is displayed under review cart
	And I close the browser successfully
	Examples:
	| text     | quantity |
	| "hammer" | "4"      |
###################END OF SCRIPT#############################