Feature: Login	
		
	As a user 
	  I want to be able to Log in 
	  so that I can start using the application

Background: 
Given the login page is showed

Scenario: Login with correct credentails 
	When the user enter the valid credentails
	Then  "Reuben" should be displayed on the dashboard


Scenario: Login with incorrect credentials
	When the user enter an invalid pasword "password"
	Then  "Your phone number or password is incorrect. Please try again." should be displayed
	
