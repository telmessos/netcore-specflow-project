Feature: Alert handling tests

Background: 
	Given user navigates to alert test page
	
Scenario Outline: Alert should display on button click
	When user clicks alert button
	Then alert should be displayed
	And alert text should be "You clicked a button"
	
Scenario Outline: Alert should display after 5 seconds
	When user clicks on delayed alert button
	And user waits for "6" seconds
	Then alert should be displayed
	And alert text should be "This alert appeared after 5 seconds"
	
Scenario Outline: Confirm box should display on button click
	When user clicks on confirm alert button
	Then alert should be displayed
	And no dismiss alert text should be "Do you confirm action?"
	When user confirms alert
	Then confirm result text should contain "You selected"
	And confirm result text should contain "Ok"
	
Scenario Outline: Prompt box should display and show expected message
	When user clicks prompt alert button
	Then alert should be displayed
	When user sends "Ceyhun Ganioglu" to prompt box
	And user accepts alert
	Then prompt result text should contain "You entered"
	And prompt result text should contain "Ceyhun Ganioglu"
	
	