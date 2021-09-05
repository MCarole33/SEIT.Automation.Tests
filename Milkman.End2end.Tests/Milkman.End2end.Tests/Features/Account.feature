Feature: Account
	As a customer
	  I want to be able to update my details
	  so that my account is update to date

Background: 
Given the customer logged in
 And the customer accounts details page is dsiplayed

Scenario: Customer updates email addresss sucessfully
	When the customer enter a valid email "test@gmail.com"
	Then the email address messge "Your account has been updated." should be successfully updated


Scenario Outline: Customer updates email addresss with invalid email format
	When the customer update the email address with <invalid email>
	Then the Error message "Please enter the valid email" should be displayed

Examples: 
| invalid email |
| testing@      |
| testing@yahoo |
| @gmail.com    |
| testing.com   |


