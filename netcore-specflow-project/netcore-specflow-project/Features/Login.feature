Feature: Login tests
	Simple login tests checking the negative and positive scenarios. 
	
Background: 
	Given user navigates to login page

Scenario: Should not login with the empty username and password
	When user tries to login with empty username and password
	Then error container should be displayed
	And error message should be "Epic sadface: Username is required"
	When user tries to login with username "standard_user" and password ""
	Then error container should be displayed
	And error message should be "Epic sadface: Password is required"
	
Scenario: Should not login with the locked out user
	When user tries to login with username "locked_out_user" and password "secret_sauce"
	Then error container should be displayed
	And error message should be "Epic sadface: Sorry, this user has been locked out."
	
Scenario: Should not login with invalid username and password
	When user tries to login with username "dummy_user" and password "secret_sauce"
	Then error container should be displayed
	And error message should be "Epic sadface: Username and password do not match any user in this service"
	When user tries to login with username "standard_user" and password "dummy_pass"
	Then error container should be displayed
	And error message should be "Epic sadface: Username and password do not match any user in this service"
	
Scenario: Should login with valid credentials
	When user tries to login with username "standard_user" and password "secret_sauce"
	Then page header should contain text "Swag Labs"
	
	