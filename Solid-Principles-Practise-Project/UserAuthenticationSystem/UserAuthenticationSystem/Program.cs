using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace UserAuthenticationSystem;

class Program
{
    static void Main()
    {
        // Pass test data
        User user = new User("john123", "password123", "john@test.com");

        // Fail Test Data
        //User user = new User("jo", "passwor", "johntest.com");

        List<IValidationRule> rules = new List<IValidationRule>();
        rules.Add(new UserNameValidationRule());
        rules.Add(new EmailValidationRule());
        rules.Add(new PasswordValidationRule());

        UserManager manager = new UserManager(
            new NotificationService(),
            new HashingService(),
            new Logger(),
            new UserRepository(),
            new ValidationService(rules),
            new AuthorisationService()
            );

        manager.RegisterUser(user);

    }
}
