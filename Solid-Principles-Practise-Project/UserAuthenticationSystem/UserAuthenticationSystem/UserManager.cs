
namespace UserAuthenticationSystem;

public class UserManager
{
    public void RegisterUser(
        string username,
        string password,
        string email)
    {
        // Validationnip
        if (username.Length < 3)
        {
            Console.WriteLine("Username too short");
            return;
        }

        if (!email.Contains("@"))
        {
            Console.WriteLine("Invalid email");
            return;
        }

        // Password hashing
        string hashedPassword = "HASHED_" + password;

        // Save to database
        File.AppendAllText(
            "users.txt",
            $"{username},{hashedPassword},{email}\n");

        // Send welcome email
        Console.WriteLine($"Sending welcome email to {email}");

        // Analytics logging
        Console.WriteLine($"Analytics: New user registered {username}");

        // Audit logging
        Console.WriteLine($"Audit Log: {username} registered");

        // Auto login
        Console.WriteLine($"{username} logged in");

        // Generate JWT token
        string token = Guid.NewGuid().ToString();

        Console.WriteLine($"JWT Token: {token}");
    }
}

