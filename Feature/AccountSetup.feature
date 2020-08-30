
Feature: Create an account on jabba talks
To create an account with names, organization name and email id

Scenario: Account_creation

# Verifying Registration functionality
Given I navigate to "https://jt-dev.azurewebsites.net/#/SignUp" signup page
When  I click on language dropdown
Then  I verify available languages "English,Dutch" from the dropdown
When  I provide my full name "PawanV"
And   I provide my organization name "PawanVatge"
And   I provide my email "jabbatalkstest@outlook.com"
And   I agree to terms and conditons
And   I click on get started button
Then  I verify a welcome email has been sent message is displayed

# Validating welcome email on Outlook
Given I navigate to "https://www.outlook.com" email client
And   I login as "jabbatalkstest@outlook.com" to email client
Then  I verify welcome email from jabba talks email address "donotreply-dev@jabatalks.com"