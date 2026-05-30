
using System.ComponentModel.DataAnnotations;

namespace UserAuthenticationSystem;

public class UserManager
{
    private readonly NotificationService _notificationService;
    private readonly AuthorisationService _authorisationService;
    private readonly HashingService _hashingService;
    private readonly Logger _logger;
    private readonly UserRepository _userRepository;
    private readonly ValidationService _validationService;

    public UserManager(
        NotificationService notificationService,
        HashingService hashingService,
        Logger logger,
        UserRepository userRepository,
        ValidationService validationService,
        AuthorisationService authorisationService)
    {
        _notificationService = notificationService;
        _hashingService = hashingService;
        _logger = logger;
        _userRepository = userRepository;
        _validationService = validationService;
        _authorisationService = authorisationService;
    }

    public void RegisterUser(User user)
    {

        // Validation
        if (!_validationService.ValidateUser(user))
        {
            return;
        }

        // Password hashing
        string hashedPassword = _hashingService.HashPassword(user.Password);

        // Save to database
        _userRepository.SaveUser(user, hashedPassword); 

        // Send welcome email
        _notificationService.SendEmail(user);

        // Analytics logging
        _logger.Log($"Analytics: New user registered {user.Username}");

        // Audit logging
        _logger.Log($"Audit Log: {user.Username} registered");

        // Auto login
        _authorisationService.Login(user.Username);

        // Generate JWT token
        string token = _authorisationService.GenerateToken();

        Console.WriteLine($"JWT Token: {token}");
    }
}

