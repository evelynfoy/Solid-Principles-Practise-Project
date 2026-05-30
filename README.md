# Solid-Principles-Practise-Project
I asked ChatGPT to provide a C# class that violates the solid principles so I could practise correcting it and structuring the project better.

# The Challenge
ChatGPT provided me with this [User Authentication System](User%20%Authenticiation%20%System.txt "User Authentication System")  project which
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
1) The first step I took was to create a new model class for the user containing user name, password and email. This gives the user data a structure 
which can be passed seemlessly berween services as required.
