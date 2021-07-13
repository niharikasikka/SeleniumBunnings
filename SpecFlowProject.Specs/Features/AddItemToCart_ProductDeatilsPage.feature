#############################################################
##This feature is a journey to navigate to Bunnings homepage
##Search for a text based on the input in feature file
##See results and go to product details page
##Click on add to cart from product details page
##Review cart
#############################################################
Feature: AddItemToCart_ProductDeatilsPage
	A simple journey to navigate to Bunnings home page and search 
	Add an item to cart from product details page
	Navigate to review cart and verify if item is successfully added
	Selenium c# miniature framework

@AddToCart1
Scenario Outline: AddItemToCart_ProductDeatilsPage_ReviewCart
	Given I navigate to bunnings home page
	When I search for a <text>
	Then I can see the results and click on the first displayed item 
	And I add to cart the first item
	And I navigate to review cart page
	And I verify that the item is displayed under review cart
	And I close the browser successfully
	Examples:
	| text     |
	| "hammer" |  
###################END OF SCRIPT#############################