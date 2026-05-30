
using System.ComponentModel.DataAnnotations;

namespace UserAuthenticationSystem;

public class UserManager
{
    public void RegisterUser(User user)
    {

        // Validation
        ValidationService validationService = new ValidationService();
        if (!validationService.ValidateUser(user))
        {
            return;
        }

        // Password hashing
        HashingService hashingService = new HashingService();
        string hashedPassword = hashingService.HashPassword(user.Password);

        // Save to database
        UserRepository userRepository = new UserRepository();
        userRepository.SaveUser(user, hashedPassword); 

        // Send welcome email
        NotificationService notificationService = new NotificationService();
        notificationService.SendEmail(user);

        // Logging
        Logger logger = new Logger();

        // Analytics logging
        logger.Log($"Analytics: New user registered {user.Username}");

        // Audit logging
        logger.Log($"Audit Log: {user.Username} registered");

        // Auto login
        AuthorisationService authorisationService = new AuthorisationService();
        authorisationService.Login(user.Username);

        // Generate JWT token
        string token = authorisationService.GenerateToken();

        Console.WriteLine($"JWT Token: {token}");
    }
}

