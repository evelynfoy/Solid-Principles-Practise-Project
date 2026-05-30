
namespace UserAuthenticationSystem;

public class UserManager
{
    public void RegisterUser(User user)
    {
        // Validationnip
        if (user.Username.Length < 3)
        {
            Console.WriteLine("Username too short");
            return;
        }

        if (!user.Email.Contains("@"))
        {
            Console.WriteLine("Invalid email");
            return;
        }

        // Password hashing
        string hashedPassword = "HASHED_" + user.Password;

        // Save to database
        File.AppendAllText(
            "users.txt",
            $"{user.Username},{hashedPassword},{user.Email}\n");

        // Send welcome email
        Console.WriteLine($"Sending welcome email to {user.Email}");

        // Analytics logging
        Console.WriteLine($"Analytics: New user registered {user.Username}");

        // Audit logging
        Console.WriteLine($"Audit Log: {user.Username} registered");

        // Auto login
        Console.WriteLine($"{user.Username} logged in");

        // Generate JWT token
        string token = Guid.NewGuid().ToString();

        Console.WriteLine($"JWT Token: {token}");
    }
}

