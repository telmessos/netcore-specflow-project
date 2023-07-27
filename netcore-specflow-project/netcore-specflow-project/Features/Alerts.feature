Feature: Alert handling tests

Scenario Outline: Alert should display on button click
	Given user navigates to alert test page
	When user clicks alert button
	Then alert should be displayed
	And alert text should be "You clicked a button"