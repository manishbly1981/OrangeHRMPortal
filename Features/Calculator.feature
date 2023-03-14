Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](MyBaseFramework/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Process User Management Cycle
	Given launch the application
	| url                                                                |
	| https://opensource-demo.orangehrmlive.com/web/index.php/auth/login |
	And Enter User Details
	| UserId | Password |
	| Admin  | admin123 |
	When click on Login button
	Then User login successfully
	Given Add new user
	And Search the user
	Then user details should display
	When delete the user
	And Search the user
	Then user details should not display