
Feature: Create an account on jabba talks
To create an account with names, organization name and email id

Scenario: Account_creation

Given I navigate to "https://jt-dev.azurewebsites.net/#/SignUp" signup page
When  I click on language dropdown
Then  I verify available languages "English,Dutch" from the dropdown
When  I provide my full name "test vatge"
And   I provide my organization name "ThinkBridge"
And   I provide my email "testtt11@outlook.com"
And   I agree to terms and conditons
And   I click on get started button
Then  I verify a welcome email has been sent message is displayed


Given I navigate to "https://www.outlook.com" email client
And   I login as "test123jabba@outlook.com" to email client
Then  I verify welcome email from jabba talks email address "donotreply-dev@jabatalks.com"

