# Solid-Principles-Practise-Project
I asked ChatGPT to provide a C# class that violates the solid principles so I could practise correcting it and structuring the project better.

# The Challenge
ChatGPT provided me with this [User Authentication System](user-authentication-system.txt "User Authentication System")  project which
violates the SOLID Principles. The challenge is to refactor the project so that 
it complies with these principles giving it a much better design.

# The Problems
1) The UserManager class violates the SRP - Singel Responsibility Principle because it is responsible for multiple functions e.g. hashing the passwords, 
saving to database, logging and sending notifications.

2) It violates the OCP - Open/Closed Principle because the user manager class is open for modification as it uses no interfaces or inheritance but has all 
functionality  in a single class. If you want to change any of these functions you need to modify existing code. 

3) It violated the DIP - Dependency Inversion Principle because it depends on concrete implementations e.g. Console and File and has no abstractions.

To refactor this code so it is complient with SOLID I will break it into services that have high cohesion and low coupling.

# The Solution
## 1. New User class
The first step I took was to create a new model class for the user containing user name, password and email. This gives the user data a structure 
which can be passed seemlessly berween services as required.

## 2. Extract different functionalities into service classes
The second step I took was to extract the different functionalities into service classes. This produced the following classes:-

		- Notifications Service
		- Authentication Service
		- Hashing Service
		- Logger
		- Validation Service
		- User Repository
			
- I included the auto login and the JWT token generation in the authentication class as these methods have high cohesion and both have the same 
  responsibility - authentication.
- I included just one method in the logger class - Log. It takes the message to be logged as a parameter so the same method can be used for all logging types.
- I included an interface as an abstraction for all classes so concrete instances could be substituted to enable compliance with the 
  LSP - Liskov Substitution Principle e.g. INotificationService or IAuthentificationService or ILogger.

## 3. Use Dependancy Injection
The third step I took was to use Dependancy Injection instead of concrete instances in the user manager class.
The instances are created in the program.cs file and passed into the user manager class so they can be used across all services. This provides a loosely coupled 
design and it complies with the DIP principle.

## 4. Use Validation Result object instead of boolean for validation
Next I replaced the boolean types I was using for validation with a new validation result object which can store not only the final 
boolean true/false result of the test but also multiple error messages. 
The boolean result is automatically set to whether the error list contains any errors.

## 5. Include a rules-based validation pattern
This step was not strictly necessary as this is a very small project and could be considered over-engineering but it was a technique I wanted to practise 
and it ensures strict compliance with the OCP principle (Open/Closed Principle).
This step was to include a rule-based validation pattern so each validation rule becomes independant.

- I created a validation rule interface requiring a Validate method for implementation.
- I then created a validation rule class implementing that interface for each validation rule e.g. Username length and valid email.
- I then added a constructor to the validation services class which takes a list of rules and stores them on instantiation. This means the set of rules to be implemented by the validation service 
  are set in the Program or calling class and passed into the validation service.
- A new rule can be added by adding a new Validation Rule class which implements the IValidationRule interface and is added to the list in the program or calling class.


