using System;
using System.IO;

namespace UserAuthenticationSystem;

class Program
{
    static void Main()
    {
        User user = new User("jo", "password", "johntest.com");

        List<IValidationRule> rules = new List<IValidationRule>();
        rules.Add(new UserNameValidationRule());
        rules.Add(new EmailValidationRule());

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
