#############################################################
##This feature is a journey to navigate to Bunnings homepage
##Search for a text based on the input in feature file
##See results and click on add to cart
##Review cart
#############################################################
Feature: AddItemToCart_AsGuest
	A simple journey to navigate to Bunnings home page and search 
	Add an item to cart
	Navigate to review cart and verify if item is successfully added
	Selenium c# miniature framework

@AddToCart
Scenario Outline: AddItemToCart_ReviewCart
	Given I navigate to bunnings home page
	When I search for a <text>
	Then I can see the results and add to cart the first search result item
	And I navigate to review cart page
	And I verify that the item is displayed under review cart
	And I close the browser successfully
	Examples:
	| text     |
	| "hammer" |  
###################END OF SCRIPT#############################